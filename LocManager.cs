using System.IO.Compression;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WinFormsLab {
    public partial class LocManager : Form {
        IDictionary<TreeNode, TreeViewElement> treeViewElementDict;
        TreeNode selectedNode;
        TreeNode selectedGroupNode;
        bool currentlyOpenFile = false;
        string prePath;

        public LocManager() {
            InitializeComponent();
            tabControl.SelectedTab = detailsTab;
            translateProgressLabel.Spring = true;
            treeView.ImageList = treeViewImageList;
            treeView.Nodes.Add(new TreeNode("<ROOT>"));
        }

        private void openToolStrip_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "LocArchive(*.zip)|*.zip";
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                currentlyOpenFile = true;
                treeViewElementDict = new Dictionary<TreeNode, TreeViewElement>();
                using (FileStream zipToOpen = new FileStream(openFileDialog.FileName, FileMode.Open)) {
                    using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read)) {
                        treeView.BeginUpdate();
                        treeView.Nodes.Clear();
                        foreach (ZipArchiveEntry entry in archive.Entries) {
                            using (StreamReader reader = new StreamReader(entry.Open())) {
                                string jsonString = reader.ReadToEnd();
                                TreeViewElement treeViewElement = JsonSerializer.Deserialize<TreeViewElement>(jsonString)!;
                                string[] hierarchyPathArray = treeViewElement.HierarchyPath.Split("-");
                                TreeNodeCollection currentNodeCollection = treeView.Nodes;

                                for (int i = 0; i < hierarchyPathArray.Length; i++) {
                                    if (!ContainsNode(currentNodeCollection, hierarchyPathArray[i])) {
                                        TreeNode entryNode = new TreeNode(hierarchyPathArray[i]);
                                        entryNode.ImageIndex = 0;
                                        entryNode.SelectedImageIndex = 0;
                                        entryNode.Tag = "group";
                                        currentNodeCollection.Add(entryNode);
                                        currentNodeCollection = currentNodeCollection[currentNodeCollection.Count - 1].Nodes;
                                    }
                                    else {
                                        currentNodeCollection = currentNodeCollection[GetCurrentIndex(currentNodeCollection, hierarchyPathArray[i])].Nodes;
                                    }

                                    if (i == hierarchyPathArray.Length - 1) {
                                        TreeNode entryNode = new TreeNode(treeViewElement.EntryName);
                                        entryNode.ImageIndex = 1;
                                        entryNode.SelectedImageIndex = 1;
                                        entryNode.Tag = "entry";
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

        public void updateDetailsTab(TreeNode node) {
            TreeViewElement element = treeViewElementDict[node];
            if (element != null) {
                pathTextBox.Text = element.HierarchyPath;
                debugTextBox.Text = element.Translations.First().Value;

                detailsListView.Items.Clear();
                foreach (var translation in element.Translations) {
                    ListViewItem item = new ListViewItem(new[] { translation.Key, translation.Value });
                    detailsListView.Items.Add(item);
                }
            }
            tabControl.SelectedTab = detailsTab;
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
            if (treeViewElementDict != null && treeViewElementDict.ContainsKey(e.Node)) {
                selectedNode = e.Node;
                updateDetailsTab(e.Node);
            }
            else {
                selectedNode = null;
                pathTextBox.Clear();
                debugTextBox.Clear();
                detailsListView.Items.Clear();
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
                            new ListViewItem(new[] { "LocKey#" + element.LocKey, element.HierarchyPath, element.Translations.First().Value });
                        searchListView.Items.Add(item);
                        searchListView.Refresh();
                    }
                }
            }
        }

        private void debugTextBox_TextChanged(object sender, EventArgs e) {
            if (treeViewElementDict != null && selectedNode != null) {
                TreeViewElement element = treeViewElementDict[selectedNode];
                if (element != null) {
                    element.Translations[element.Translations.First().Key] = debugTextBox.Text;
                    updateDetailsTab(selectedNode);
                }
            }
        }

        private void saveAsToolStrip_Click(object sender, EventArgs e) {
            if (!currentlyOpenFile)
                return;
            //reference: stackoverflow
            //https://stackoverflow.com/questions/17232414/creating-a-zip-archive-in-memory-using-system-io-compression
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "LocArchive(*.zip)|*.zip";
            saveFileDialog.Title = "Save The Archive";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {

                using (var memoryStream = new MemoryStream()) {

                    using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true)) {

                        foreach (TreeViewElement element in treeViewElementDict.Values) {
                            string jsonFileString = JsonSerializer.Serialize(element);
                            var jsonFile = archive.CreateEntry("LocKey#" + element.LocKey + ".json");
                            using (var entryStream = jsonFile.Open()) {
                                using (var streamWriter = new StreamWriter(entryStream)) {
                                    streamWriter.Write(jsonFileString);
                                }
                            }
                        }
                    }

                    using (var fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create)) {
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        memoryStream.CopyTo(fileStream);
                    }
                }
            }

        }

        private void searchListView_DoubleClick(object sender, EventArgs e) {
            if (searchListView.SelectedItems.Count == 1) {
                string cellText = searchListView.SelectedItems[0].Text;
                foreach (KeyValuePair<TreeNode, TreeViewElement> keyVal in treeViewElementDict) {
                    if (cellText.Substring(7) == keyVal.Value.LocKey) {
                        selectedNode = keyVal.Key;
                        updateDetailsTab(keyVal.Key);
                    }
                }
            }
            searchListView.Items.Clear();
            searchTextBox.Clear();
        }

        private void deleteEntryToolStrip_Click(object sender, EventArgs e) {
            if (selectedNode != null) {
                if (selectedNode == treeView.SelectedNode) {
                    debugTextBox.Clear();
                    pathTextBox.Clear();
                    detailsListView.Items.Clear();
                    treeViewElementDict.Remove(selectedNode);
                    treeView.SelectedNode.Remove();
                }

            }
        }

        private void newEntryToolStrip_Click(object sender, EventArgs e) {
            if (treeView.SelectedNode.Tag == "group") {
                prePath = treeView.SelectedNode.Text + "-";
                pathTextBox.Text = prePath;
                pathTextBox.ReadOnly = false;
            }
        }

        private void pathTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                pathTextBox.ReadOnly = true;
                string entryText = pathTextBox.Text.Substring(prePath.Length);
                TreeNode newEntryNode = new TreeNode(entryText);
                newEntryNode.ImageIndex = 1;
                newEntryNode.SelectedImageIndex = 1;
                newEntryNode.Tag = "entry";

                TreeViewElement newEntryElement = new TreeViewElement(pathTextBox.Text, entryText);
                treeViewElementDict.Add(newEntryNode, newEntryElement);
                treeView.SelectedNode.Nodes.Add(newEntryNode);
                treeView.SelectedNode.Expand();
                selectedNode = newEntryNode;
            }
        }

        private void treeView_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                TreeNode node = treeView.GetNodeAt(e.X, e.Y);
                if (node.Tag == "group") {
                    selectedGroupNode = node;
                    nodeRightClickContextMenuStrip.Show(Cursor.Position);
                    treeView.SelectedNode = selectedGroupNode;
                }
            }
        }

        private void deleteGroupMenuItem_Click(object sender, EventArgs e) {
            treeView.BeginUpdate();
            treeView.SelectedNode.Remove();
            treeView.EndUpdate();
        }

        private void newSubGroupMenuItem_Click(object sender, EventArgs e) {
            TreeNode subGroupNode = new TreeNode("<New SubGroup Node>");
            subGroupNode.ImageIndex = 0;
            subGroupNode.SelectedImageIndex = 0;
            subGroupNode.Tag = "group";

            treeView.BeginUpdate();
            treeView.LabelEdit = true;
            treeView.SelectedNode.Nodes.Add(subGroupNode);
            treeView.SelectedNode.Expand();
            if (!subGroupNode.IsEditing) {
                subGroupNode.BeginEdit();
            }
            treeView.EndUpdate();
        }

        private void newGroupMenuItem_Click(object sender, EventArgs e) {
            TreeNode groupNode = new TreeNode("<New Group Node>");
            groupNode.ImageIndex = 0;
            groupNode.SelectedImageIndex = 0;
            groupNode.Tag = "group";

            treeView.BeginUpdate();
            treeView.LabelEdit = true;
            TreeNode upperNode = treeView.SelectedNode.Parent;
            if (upperNode == null)
                treeView.Nodes.Add(groupNode);
            else
                upperNode.Nodes.Add(groupNode);
            treeView.SelectedNode.Expand();
            if(!groupNode.IsEditing) {
                groupNode.BeginEdit();
            }
            treeView.EndUpdate();
        }
    }

    public class TreeViewElement {
        public string LocKey { get; set; }
        public string HierarchyPath { get; set; }
        public string EntryName { get; set; }
        public IDictionary<string, string> Translations { get; set; }

        public TreeViewElement(string hierarchyPath, string entryName) {
            this.EntryName = entryName;
            this.HierarchyPath = hierarchyPath;

            this.Translations = new Dictionary<string, string>();
            Translations.Add("Debug", "");

            this.LocKey = $"{this.HierarchyPath}-{this.EntryName}".GetHashCode().ToString() + "01od1".GetHashCode();
        }



    }
}