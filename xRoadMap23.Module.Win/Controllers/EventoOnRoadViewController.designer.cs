using xRoadMap.Module.BusinessObjects;

namespace xRoadMap.Module.Win.Controllers
{
    partial class EventoOnRoadViewController
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
            this.simpleActionLocate = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.simpleActionLocateRoad = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.simpleActionUpdateEvent = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.actionGetIFrame = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // simpleActionLocate
            // 
            this.simpleActionLocate.Caption = "Aggiorna PK";
            this.simpleActionLocate.Category = "Edit";
            this.simpleActionLocate.ConfirmationMessage = null;
            this.simpleActionLocate.Id = "LineLocateAlongRoute";
            this.simpleActionLocate.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.simpleActionLocate.TargetObjectsCriteria = "Tipo = ##Enum#xRoadMap.Module.BusinessObjects.TipoPosizione,Coordinate# AND Strada IS NOT NULL";
            this.simpleActionLocate.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.simpleActionLocate.ToolTip = "Aggiorna le progressive chilometriche in base alla geometria.";
            this.simpleActionLocate.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.simpleActionLocate.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.simpleActionLocate_Execute);
            // 
            // simpleActionLocateRoad
            // 
            this.simpleActionLocateRoad.Caption = "Localizza strada";
            this.simpleActionLocateRoad.Category = "Edit";
            this.simpleActionLocateRoad.ConfirmationMessage = null;
            this.simpleActionLocateRoad.Id = "LocateRoute";
            this.simpleActionLocateRoad.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireMultipleObjects;
            this.simpleActionLocateRoad.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.simpleActionLocateRoad.TargetObjectsCriteria = $"{nameof(IEventoOnRoad.Strada)} IS NULL";
            this.simpleActionLocateRoad.ToolTip = "Assegna la strada provinciale più vicina.";
            this.simpleActionLocateRoad.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.simpleActionLocateRoad_Execute);
            // 
            // simpleActionUpdateEvent
            // 
            this.simpleActionUpdateEvent.Caption = "Aggiorna geometria";
            this.simpleActionUpdateEvent.Category = "Edit";
            this.simpleActionUpdateEvent.ConfirmationMessage = null;
            this.simpleActionUpdateEvent.Id = "AggiornaGeometria";
            this.simpleActionUpdateEvent.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireMultipleObjects;
            this.simpleActionUpdateEvent.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.simpleActionUpdateEvent.TargetObjectsCriteria = "Tipo <> ##Enum#xRoadMap.Module.BusinessObjects.TipoPosizione,Coordinate# AND Strada IS NOT NULL";
            this.simpleActionUpdateEvent.ToolTip = "Aggiorna geometria in base alle progressive chilometriche.";
            this.simpleActionUpdateEvent.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.simpleActionUpdateEvent_Execute);
            // 
            // actionGetIFrame
            // 
            this.actionGetIFrame.AcceptButtonCaption = null;
            this.actionGetIFrame.CancelButtonCaption = null;
            this.actionGetIFrame.Caption = "IFrame";
            this.actionGetIFrame.Category = "Edit";
            this.actionGetIFrame.ConfirmationMessage = null;
            this.actionGetIFrame.Id = "GetIFrame";
            this.actionGetIFrame.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.actionGetIFrame.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.actionGetIFrame.ToolTip = "Ottiene il codice html per incorporare la mappa";
            this.actionGetIFrame.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.actionGetIFrame.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.actionGetIFrame_CustomizePopupWindowParams);
            this.actionGetIFrame.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.actionGetIFrame_Execute);
            // 
            // LinearReferencingViewController
            // 
            this.Actions.Add(this.simpleActionLocate);
            this.Actions.Add(this.simpleActionLocateRoad);
            this.Actions.Add(this.simpleActionUpdateEvent);
            this.Actions.Add(this.actionGetIFrame);

        }

        #endregion
        private DevExpress.ExpressApp.Actions.SimpleAction simpleActionUpdateEvent;
        private DevExpress.ExpressApp.Actions.SimpleAction simpleActionLocate;
        private DevExpress.ExpressApp.Actions.SimpleAction simpleActionLocateRoad;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction actionGetIFrame;

    }
}
