namespace xRoadMap.Module.Controllers
{
    partial class cspraWindowController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem1 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem2 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem3 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem4 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem5 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem6 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            this.actionImport = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            // 
            // actionImport
            // 
            this.actionImport.Caption = "Importa da cspra";
            this.actionImport.Category = "Tools";
            this.actionImport.ConfirmationMessage = null;
            this.actionImport.Id = "ImportCspra";
            choiceActionItem1.Caption = "Tombini";
            choiceActionItem1.Id = "Tombini";
            choiceActionItem1.ImageName = null;
            choiceActionItem1.Shortcut = null;
            choiceActionItem1.ToolTip = null;
            choiceActionItem2.Caption = "Ponti e viadotti";
            choiceActionItem2.Id = "Ponti";
            choiceActionItem2.ImageName = null;
            choiceActionItem2.Shortcut = null;
            choiceActionItem2.ToolTip = null;
            choiceActionItem3.Caption = "Tratti urbani";
            choiceActionItem3.Id = "TrattiUrbani";
            choiceActionItem3.ImageName = null;
            choiceActionItem3.Shortcut = null;
            choiceActionItem3.ToolTip = null;
            choiceActionItem4.Caption = "Accessi";
            choiceActionItem4.Id = "Accessi";
            choiceActionItem4.ImageName = null;
            choiceActionItem4.Shortcut = null;
            choiceActionItem4.ToolTip = null;
            choiceActionItem5.Caption = "Aree Traffico";
            choiceActionItem5.Id = "AreeTraffico";
            choiceActionItem6.Caption = "Banchine";
            choiceActionItem6.Id = "Banchine";
            this.actionImport.Items.Add(choiceActionItem1);
            this.actionImport.Items.Add(choiceActionItem2);
            this.actionImport.Items.Add(choiceActionItem3);
            this.actionImport.Items.Add(choiceActionItem4);
            this.actionImport.Items.Add(choiceActionItem5);
            this.actionImport.Items.Add(choiceActionItem6);
            this.actionImport.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation;
            this.actionImport.ShowItemsOnClick = true;
            this.actionImport.ToolTip = null;
            this.actionImport.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.actionImport_Execute);
            // 
            // cspraWindowController
            // 
            this.Actions.Add(this.actionImport);
            this.TargetWindowType = DevExpress.ExpressApp.WindowType.Main;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SingleChoiceAction actionImport;
    }
}
