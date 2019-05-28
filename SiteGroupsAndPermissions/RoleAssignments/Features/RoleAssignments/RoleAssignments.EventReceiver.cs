using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;

namespace RoleAssignments.Features.RoleAssignments
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("861eeab8-897a-4e5d-9737-1f100a3e397a")]
    public class RoleAssignmentsEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPSite site = properties.Feature.Parent as SPSite;
            SPWeb web = site.RootWeb;

            SPUser currentUser = web.CurrentUser;

            SPGroupCollection groups = web.SiteGroups;

            groups.Add("Project Managers", currentUser, currentUser, "All Project Managers are in this group");
            SPGroup projectManagers = groups["Project Managers"];

            groups.Add("Team Leaders", projectManagers, currentUser, "All team leaders are in this group");
            SPGroup teamLeaders = groups["Team Leaders"];

            groups.Add("Developers", teamLeaders, currentUser, "All Developers are in this group");
            SPGroup Developers = groups["Developers"];

            SPRoleDefinition fullControl = web.RoleDefinitions["Full Control"];
            SPRoleDefinition contribute = web.RoleDefinitions["Contribute"];
            SPRoleDefinition read = web.RoleDefinitions["Read"];

            SPRoleAssignment projectManagerRoleAssignment = new SPRoleAssignment(projectManagers);
            projectManagerRoleAssignment.RoleDefinitionBindings.Add(fullControl);
            web.RoleAssignments.Add(projectManagerRoleAssignment);

            SPRoleAssignment teamLeadersManagerRoleAssignment = new SPRoleAssignment(teamLeaders);
            teamLeadersManagerRoleAssignment.RoleDefinitionBindings.Add(contribute);
            web.RoleAssignments.Add(teamLeadersManagerRoleAssignment);

            SPRoleAssignment developersRoleAssignment = new SPRoleAssignment(Developers);
            developersRoleAssignment.RoleDefinitionBindings.Add(read);
            web.RoleAssignments.Add(developersRoleAssignment);

            SPList workPackageList = web.Lists["WorkPackage"];
            workPackageList.BreakRoleInheritance(true);
            developersRoleAssignment.RoleDefinitionBindings.Add(contribute);
            workPackageList.RoleAssignments.Add(developersRoleAssignment);

            web.EnsureUser("DEMO\\sp_marina");
            web.SiteGroups["Project Managers"].AddUser("DEMO\\sp_marina", "sp_marina@demo.local", "Marina Canales", "");

            web.EnsureUser("DEMO\\soledad_valdes");
            web.SiteGroups["Team Leaders"].AddUser("DEMO\\soledad_valdes", "soledad_valdes@demo.local", "Soledad Valdes", "");

            web.EnsureUser("DEMO\\claudio_parra");
            web.SiteGroups["Developers"].AddUser("DEMO\\claudio_parra", "claudio_parra@demo.local", "Claudio Parra", "");

        }


    // Uncomment the method below to handle the event raised before a feature is deactivated.

    public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
    {
            SPSite site = properties.Feature.Parent as SPSite;
            SPWeb rootWeb = site.RootWeb;
            SPGroupCollection groups = rootWeb.SiteGroups;

            groups.Remove("Project Managers");
            groups.Remove("Team Leaders");
            groups.Remove("Developers");

            SPList workPackageList = rootWeb.Lists["WorkPackage"];
            workPackageList.ResetRoleInheritance();
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
