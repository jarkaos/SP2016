using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Navigation;

namespace NavigationDemo.Features.NavigationDemo
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("d938ad93-dac8-4d4a-bd28-9d52dfa6f25c")]
    public class NavigationDemoEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPWeb currentWeb = properties.Feature.Parent as SPWeb;

            SPNavigation webNavigation = currentWeb.Navigation;
            SPNavigationNodeCollection quickLaunchNodes = webNavigation.QuickLaunch;
            SPNavigationNode qln = quickLaunchNodes.AddAsLast(new SPNavigationNode("My custom heading", "/"));
            SPNavigationNode bt = qln.Children.AddAsFirst(new SPNavigationNode("Belfast Trainers", "Lists/BelfastTrainers"));

            qln.Children.Add(new SPNavigationNode("New Trainers", "Lists/NewTrainers"), bt);
            qln.Children.AddAsLast(new SPNavigationNode("ItAcademy Trainers", "Lists/ITAcademyTrainers"));

            SPNavigationNodeCollection topLinkBarNodes = webNavigation.TopNavigationBar;
            topLinkBarNodes.AddAsLast(new SPNavigationNode("Belfast Trainers", "Lists/BelfastTrainers"));
            topLinkBarNodes.AddAsLast(new SPNavigationNode("ItAcademy Trainers", "Lists/ITAcademyTrainers"));
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPWeb currentWeb = properties.Feature.Parent as SPWeb;

            SPNavigation webNavigation = currentWeb.Navigation;
            SPNavigationNodeCollection quickLaunchNodes = webNavigation.QuickLaunch;
            SPNavigationNodeCollection topLinkBarNodes = webNavigation.TopNavigationBar;

            foreach (SPNavigationNode quickLaunchNode in quickLaunchNodes)
            {
                if (quickLaunchNode.Title == "My custom heading")
                {
                    quickLaunchNodes.Delete(quickLaunchNode);
                }
            }

            for (int i = topLinkBarNodes.Count -1; i > 0; i--)
            {
                SPNavigationNode topLinkBarNode = topLinkBarNodes[i];
                if (topLinkBarNode.Title == "Belfast Trainers" || topLinkBarNode.Title == "ItAcademy Trainers")
                {
                    topLinkBarNodes.Delete(topLinkBarNode);
                }

            }
        }


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
