namespace xRoadMap.Module.Controllers
{
    partial class OrdinanzaViewController
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
            this.actionFiltraOrdinanze = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            // 
            // actionFiltraOrdinanze
            // 
            this.actionFiltraOrdinanze.Caption = "Filtro Ordinanza Vigente";
            this.actionFiltraOrdinanze.Category = "Filters";
            this.actionFiltraOrdinanze.ConfirmationMessage = null;
            this.actionFiltraOrdinanze.Id = "FiltroOrdinanzaVigente";
            choiceActionItem1.Caption = "Tutte";
            choiceActionItem1.Id = "Tutte";
            choiceActionItem1.ImageName = null;
            choiceActionItem1.Shortcut = null;
            choiceActionItem1.ToolTip = null;
            choiceActionItem2.Caption = "Vigenti";
            choiceActionItem2.Id = "Vigenti";
            choiceActionItem2.ImageName = null;
            choiceActionItem2.Shortcut = null;
            choiceActionItem2.ToolTip = null;
            choiceActionItem3.Caption = "Non vigenti";
            choiceActionItem3.Id = "NonVigenti";
            choiceActionItem3.ImageName = null;
            choiceActionItem3.Shortcut = null;
            choiceActionItem3.ToolTip = null;
            this.actionFiltraOrdinanze.Items.Add(choiceActionItem1);
            this.actionFiltraOrdinanze.Items.Add(choiceActionItem2);
            this.actionFiltraOrdinanze.Items.Add(choiceActionItem3);
            this.actionFiltraOrdinanze.ToolTip = null;
            this.actionFiltraOrdinanze.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.actionFiltraOrdinanze_Execute);
            // 
            // OrdinanzaViewController
            // 
            this.Actions.Add(this.actionFiltraOrdinanze);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SingleChoiceAction actionFiltraOrdinanze;
    }
}
