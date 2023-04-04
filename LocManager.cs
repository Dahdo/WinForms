using System.IO.Compression;
using System.Text.Json;

namespace WinFormsLab {
    public partial class LocManager : Form {
        IDictionary<TreeNode, TreeViewElement> treeViewElementDict;
        public LocManager() {
            InitializeComponent();
            tabControl.SelectedTab = detailsTab;
            translateProgressLabel.Spring = true;
        }

        private void openToolStrip_Click(object sender, EventArgs e) {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "LocArchive(*.zip)|*.zip";
            if (fileDialog.ShowDialog() == DialogResult.OK) {
                treeViewElementDict = new Dictionary<TreeNode, TreeViewElement>();
                using (FileStream zipToOpen = new FileStream(fileDialog.FileName, FileMode.Open)) {
                    using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read)) {
                        treeView.BeginUpdate();
                        foreach (ZipArchiveEntry entry in archive.Entries) {
                            using (StreamReader reader = new StreamReader(entry.Open())) {
                                string jsonString = reader.ReadToEnd();
                                TreeViewElement treeViewElement = JsonSerializer.Deserialize<TreeViewElement>(jsonString)!;
                                string[] hierarchyPathArray = treeViewElement.HierarchyPath.Split("-");
                                TreeNodeCollection currentNodeCollection = treeView.Nodes;

                                for (int i = 0; i < hierarchyPathArray.Length; i++) {
                                    if (!ContainsNode(currentNodeCollection, hierarchyPathArray[i])) {
                                        currentNodeCollection.Add(new TreeNode(hierarchyPathArray[i]));
                                        currentNodeCollection = currentNodeCollection[currentNodeCollection.Count - 1].Nodes;
                                    }
                                    else {
                                        currentNodeCollection = currentNodeCollection[GetCurrentIndex(currentNodeCollection, hierarchyPathArray[i])].Nodes;
                                    }

                                    if (i == hierarchyPathArray.Length - 1) {
                                        TreeNode entryNode = new TreeNode(treeViewElement.EntryName);
                                        currentNodeCollection.Add(entryNode);
                                        treeViewElementDict.Add(entryNode, treeViewElement);
                                    }
                                }
                            }

                        }
                        treeView.EndUpdate();
                    }
                }
            }

        }

        public bool ContainsNode(TreeNodeCollection nodeCollection, string nodeText) {
            if (nodeCollection.Count > 0) {
                foreach (TreeNode node in nodeCollection) {
                    if (node.Text == nodeText)
                        return true;
                }
            }
            return false;
        }

        public int GetCurrentIndex(TreeNodeCollection nodeCollection, string nodeText) {
            int index = 0;
            if (nodeCollection.Count > 0) {
                foreach (TreeNode node in nodeCollection) {
                    if (node.Text == nodeText)
                        return index;
                    index++;
                }
            }
            return index;
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
            if (treeViewElementDict.ContainsKey(e.Node)) {
                TreeViewElement element = treeViewElementDict[e.Node];
                if (element != null) {
                    pathTextBox.Text = element.HierarchyPath;
                    debugTextBox.Text = element.Translations.First().Value;

                    detailsListView.Items.Clear();
                    foreach (var translation in element.Translations) {
                        ListViewItem item = new ListViewItem(new[] { translation.Key, translation.Value });
                        detailsListView.Items.Add(item);
                    }
                }
            }
        }


        private void searchButton_Click(object sender, EventArgs e) {
            validateSearch();
        }

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                validateSearch();
            }

        }

        private void validateSearch() {
            searchListView.Items.Clear();
            string searchString = searchTextBox.Text;
            if (treeViewElementDict != null) {
                foreach (TreeViewElement element in treeViewElementDict.Values) {
                    if (element.HierarchyPath.Contains(searchString, System.StringComparison.CurrentCultureIgnoreCase)) {
                        ListViewItem item =
                            new ListViewItem(new[] { "LocKey" + element.LocKey, element.HierarchyPath, element.Translations.First().Value });
                        searchListView.Items.Add(item);
                    }
                }
            }
        }
    }

    public class TreeViewElement {
        public string LocKey { get; set; }
        public string HierarchyPath { get; set; }
        public string EntryName { get; set; }
        public IDictionary<string, string> Translations { get; set; }
    }
}