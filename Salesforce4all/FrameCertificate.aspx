<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FrameCertificate.aspx.vb" Inherits="Salesforce4all.FrameCertificate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Salesforce4All</title>

    <link rel="icon" href="Images/index2.png">

     <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-109851018-1"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'UA-109851018-1');
    </script>


    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <link href="css/modern-business.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="css/image-picker.css">

    <script src="scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="scripts/image-picker.min.js" type="text/javascript"></script>

    <style>
        .body {
            padding: 0px;
            
        }
        .thumbnail {
            margin-top: 10px;
            margin-left: 45px;
        }
        .card-header-salesforce {
          padding: 0.75rem 1.25rem;
          margin-bottom: 0;
          background-color: rgba(0, 136, 204, 0.7);
          border-bottom: 1px solid rgba(0, 0, 0, 0.125);
        }

    </style>

   

</head>


<%--    https://startbootstrap.com/template-overviews/modern-business/--%>

<body onload="javascript:codeAddress();" style ="padding: 0px;">
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
          <div id="drawZone" style ="display:none" >
                 <div class="row">
                        <div id="container">
                            <canvas id="c" width="1400" height="320"></canvas>
                        </div>
                    </div>
         </div>
        <div id="divCheckbox" style="display: none;">
         <select runat="server" title="Selecciona tu imagen preferida" class="image-picker show-labels show-html" id="imageSelected"  style="display: none">
                                    <option data-img-src='Images/12/header-bg-1.png' value='header-bg-1'>Cabin</option>
                                    <option data-img-src='Images/12/header-bg-2.png' value='header-bg-2'>Morning</option>
                                    <option data-img-src='Images/12/header-bg-3.png' value='header-bg-3'>Sun</option>
                                    <option data-img-src='Images/12/header-bg-4.png' value='header-bg-4'>Night</option>

                                    <option data-img-src='Images/12/header-bg-5.png' value='header-bg-5'>Lake</option>
                                    <option data-img-src='Images/12/header-bg-6.png' value='header-bg-6'>Beach</option>
                                    <option data-img-src='Images/12/header-bg-7.png' value='header-bg-7'>Mountain</option>
                                    <option data-img-src='Images/12/header-bg-8.png' value='header-bg-8'>Fjord</option>

                                    <option data-img-src='Images/12/header-bg-9.png' value='header-bg-9'>Hill</option>
                                    <option data-img-src='Images/12/header-bg-10.png' value='header-bg-10'>Forest</option>
                                    <option data-img-src='Images/12/header-bg-11.png' value='header-bg-11'>Route</option>
                                    <option data-img-src='Images/12/header-bg-12.png' value='header-bg-12'>Alps</option>

                                    <option data-img-src='Images/12/header-bg-13.png' value='header-bg-13'>Canyon</option>
                                    <option data-img-src='Images/12/header-bg-14.png' value='header-bg-14'>Mountain Range</option>
                                    <option data-img-src='Images/12/header-bg-15.png' value='header-bg-15'>Cliff</option>

                                    <option data-img-src='Images/12Trailhead/header-bg-1.png' value='header-bg-t1'>Forest</option>
                                    <option data-img-src='Images/12Trailhead/header-bg-2.png' value='header-bg-t2'>Sunrise</option>
                                    <option data-img-src='Images/12Trailhead/header-bg-3.png' value='header-bg-t3'>Morning</option>
                                    <option data-img-src='Images/12Trailhead/header-bg-4.png' value='header-bg-t4'>Night</option>
               
                                </select>
            </div>

        <img src="Images/Original/header-bg-1.png" id="header-bg-1" style="display: none;">
        <img src="Images/Original/header-bg-2.png" id="header-bg-2" style="display: none;">
        <img src="Images/Original/header-bg-3.png" id="header-bg-3" style="display: none;">
        <img src="Images/Original/header-bg-4.png" id="header-bg-4" style="display: none;">

        <img src="Images/Original/header-bg-5.png" id="header-bg-5" style="display: none;">
        <img src="Images/Original/header-bg-6.png" id="header-bg-6" style="display: none;">
        <img src="Images/Original/header-bg-7.png" id="header-bg-7" style="display: none;">
        <img src="Images/Original/header-bg-8.png" id="header-bg-8" style="display: none;">

        <img src="Images/Original/header-bg-9.png" id="header-bg-9" style="display: none;">
        <img src="Images/Original/header-bg-10.png" id="header-bg-10" style="display: none;">
        <img src="Images/Original/header-bg-11.png" id="header-bg-11" style="display: none;">
        <img src="Images/Original/header-bg-12.png" id="header-bg-12" style="display: none;">

        <img src="Images/Original/header-bg-13.png" id="header-bg-13" style="display: none;">
        <img src="Images/Original/header-bg-14.png" id="header-bg-14" style="display: none;">
        <img src="Images/Original/header-bg-15.png" id="header-bg-15" style="display: none;">

          <img src="Images/OriginalTrailhead/header-bg-1.png" id="header-bg-t1" style="display: none;">
        <img src="Images/OriginalTrailhead/header-bg-2.png" id="header-bg-t2" style="display: none;">
        <img src="Images/OriginalTrailhead/header-bg-3.png" id="header-bg-t3" style="display: none;">
        <img src="Images/OriginalTrailhead/header-bg-4.png" id="header-bg-t4" style="display: none;">



         <img src="Images/Certificates/.cert-badge.Certified.Administrator.jpg" id="Salesforce Certified Administrator" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Advanced.Administrator.jpg" id="Salesforce Certified Advanced Administrator" style="display: none;">
        <%--<img src="Images/Certificates/.cert-badge.Certified.Advanced.Developer.jpg" id="Salesforce Certified Platform Developer II" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Developer.jpg" id="Salesforce Certified Platform Developer I" style="display: none;">
        --%><img src="Images/Certificates/.cert-badge.Certified.Sales.Consultant.jpg" id="Salesforce Certified Sales Cloud Consultant" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Service.Consultant.jpg" id="Salesforce Certified Service Cloud Consultant" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Technical.Architect.jpg" id="Salesforce Certified Technical Architect" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.System.Architect.jpg" id="Salesforce Certified System Architect" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Application.Architect.jpg" id="Salesforce Certified Application Architect" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Pardot.Consultant.jpg" id="Salesforce Certified Pardot Consultant" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Pardot.User.jpg" id="Salesforce Certified Pardot Specialist" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.App.Builder.jpg" id="Salesforce Certified Platform App Builder" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Marketing.Cloud.Email.Specialist.jpg" id="Salesforce Certified Marketing Cloud Email Specialist" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Marketing.Cloud.Social.Specialist.jpg" id="Certified Marketing Cloud Social Specialist" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Programmer.I.jpg" id="Salesforce Certified Platform Developer I" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Programmer.II.jpg" id="Salesforce Certified Platform Developer II" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Data.Architecture.and.Management.Specialist.jpg" id="Salesforce Certified Data Architecture & Management Designer" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Development.Lifecycle.and.Deployment.Specialist.jpg" id="Salesforce Certified Development Lifecycle and Deployment Designer" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Integration.Architecture.Specialist.jpg" id="Salesforce Certified Integration Architecture Designer" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Marketing.Cloud.Consultant.jpg" id="Salesforce Certified Marketing Cloud Consultant" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Marketing.Cloud.Developer.jpg" id="Salesforce Certified Marketing Cloud Developer" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Sharing.and.Visibility.Designer.jpg" id="Salesforce Certified Sharing and Visibility Designer" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Identity.and.Access.Management.Designer.jpg" id="Salesforce Certified Identity and Access Management Designer" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Mobile.Solutions.Architecture.Designer.jpg" id="Salesforce Certified Mobile Solutions Architecture Designer" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Community.Cloud.Consultant.jpg" id="Salesforce Certified Community Cloud Consultant" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.CPQ.Specialist.jpg" id="Salesforce Certified CPQ Specialist" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.B2C.Commerce.Developer.jpg" id="Salesforce Certified B2C Commerce Developer" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.B2C.Commerce.Technical.Solution.Designer.jpg" id="Salesforce Certified B2C Technical Solution Designer" style="display: none;">
      <%--  <img src="Images/Certificates/.cert-badge.Certified.Commerce.Cloud.Digital.Developer.jpg" id="YaNoExiste1" style="display: none;">
      --%>  
        <img src="Images/Certificates/.cert-badge.Accredited.Sales.Professional.jpg" id="Accredited Sales Professional" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Accredited.Presales.Professional.jpg" id="Accredited Presales Professional" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Nonprofit.Cloud.Consultant.jpg" id="Salesforce Certified Nonprofit Cloud Consultant" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Field.Service.Lightning.Consultant.jpg" id="Salesforce Certified Field Service Lightning" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Einstein.Analytics.Discovery.Consultant.png" id="Salesforce Certified Einstein Analytics and Discovery Consultant" style="display: none;">
      
           <img src="Images/Certificates/.cert-badge.Certified.Education.Cloud.Consultant.jpg " id="Salesforce Certified Education Cloud Consultant" style="display: none;">
     
           <img src="Images/Certificates/.cert-badge.Certified.Heroku.Architecture.Designer.png" id="Salesforce Certified Heroku Architecture Designer" style="display: none;">
     

      <%-- <img src="Images/Certificates/.cert-badge.Certified.Administrator.jpg" id="Certified Administrator" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Advanced.Administrator.jpg" id="Certified Advanced Administrator" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Advanced.Developer.jpg" id="Certified Advanced Developer" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Developer.jpg" id="Certified Developer" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Sales.Consultant.jpg" id="Certified Sales Consultant" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Service.Consultant.jpg" id="Certified Service Consultant" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Technical.Architect.jpg" id="Certified Technical Architect" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.System.Architect.jpg" id="Certified System Architect" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Application.Architect.jpg" id="Certified Application Architect" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Pardot.Consultant.jpg" id="Certified Pardot Consultant" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Pardot.User.jpg" id="Certified Pardot User" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.App.Builder.jpg" id="Certified App Builder" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Marketing.Cloud.Email.Specialist.jpg" id="Certified Marketing Cloud Email Specialist" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Marketing.Cloud.Social.Specialist.jpg" id="Certified Marketing Cloud Social Specialist" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Programmer.I.jpg" id="Certified Programmer I" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Programmer.II.jpg" id="Certified Programmer II" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Data.Architecture.and.Management.Specialist.jpg" id="Certified Data Architecture and Management Specialist" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Development.Lifecycle.and.Deployment.Specialist.jpg" id="Certified Development Lifecycle and Deployment Specialist" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Integration.Architecture.Specialist.jpg" id="Certified Integration Architecture Specialist" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Marketing.Cloud.Consultant.jpg" id="Certified Marketing Cloud Consultant" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Sharing.and.Visibility.Designer.jpg" id="Certified Sharing and Visibility Designer" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Identity.and.Access.Management.Designer.jpg" id="Certified Identity and Access Management Designer" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Mobile.Solutions.Architecture.Designer.jpg" id="Certified Mobile Solutions Architecture Designer" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Community.Cloud.Consultant.jpg" id="Certified Community Cloud Consultant" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.CPQ.Specialist.jpg" id="Certified CPQ Specialist" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Field.Service.Lightning.Consultant.jpg" id="Certified Field Service Lightning Consultant" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Commerce.Cloud.Digital.Developer.jpg" id="Certified Commerce Cloud Digital Developer" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Accredited.Sales.Professional.jpg" id="Accredited Sales Professional" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Accredited.Presales.Professional.jpg" id="Accredited Presales Professional" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Nonprofit.Cloud.Consultant.jpg" id="Certified Nonprofit Cloud Consultant" style="display: none;">--%>


       <%-- <img src="Images/Certificates/.cert-badge.Certified.Administrator.jpg" id=".cert-badge.Certified.Administrator" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Advanced.Administrator.jpg" id=".cert-badge.Certified.Advanced.Administrator" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Advanced.Developer.jpg" id=".cert-badge.Certified.Advanced.Developer" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Developer.jpg" id=".cert-badge.Certified.Developer" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Sales.Consultant.jpg" id=".cert-badge.Certified.Sales.Consultant" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Service.Consultant.jpg" id=".cert-badge.Certified.Service.Consultant" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Technical.Architect.jpg" id=".cert-badge.Certified.Technical.Architect" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.System.Architect.jpg" id=".cert-badge.Certified.System.Architect" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Application.Architect.jpg" id=".cert-badge.Certified.Application.Architect" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Pardot.Consultant.jpg" id=".cert-badge.Certified.Pardot.Consultant" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Pardot.User.jpg" id=".cert-badge.Certified.Pardot.User" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.App.Builder.jpg" id=".cert-badge.Certified.App.Builder" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Marketing.Cloud.Email.Specialist.jpg" id=".cert-badge.Certified.Marketing.Cloud.Email.Specialist" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Marketing.Cloud.Social.Specialist.jpg" id=".cert-badge.Certified.Marketing.Cloud.Social.Specialist" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Programmer.I.jpg" id=".cert-badge.Certified.Programmer.I" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Programmer.II.jpg" id=".cert-badge.Certified.Programmer.II" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Data.Architecture.and.Management.Specialist.jpg" id=".cert-badge.Certified.Data.Architecture.and.Management.Specialist" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Development.Lifecycle.and.Deployment.Specialist.jpg" id=".cert-badge.Certified.Development.Lifecycle.and.Deployment.Specialist" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Integration.Architecture.Specialist.jpg" id=".cert-badge.Certified.Integration.Architecture.Specialist" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Marketing.Cloud.Consultant.jpg" id=".cert-badge.Certified.Marketing.Cloud.Consultant" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Sharing.and.Visibility.Designer.jpg" id=".cert-badge.Certified.Sharing.and.Visibility.Designer" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Identity.and.Access.Management.Designer.jpg" id=".cert-badge.Certified.Identity.and.Access.Management.Designer" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Mobile.Solutions.Architecture.Designer.jpg" id=".cert-badge.Certified.Mobile.Solutions.Architecture.Designer" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Community.Cloud.Consultant.jpg" id=".cert-badge.Certified.Community.Cloud.Consultant" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.CPQ.Specialist.jpg" id=".cert-badge.Certified.CPQ.Specialist" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Field.Service.Lightning.Consultant.jpg" id=".cert-badge.Certified.Field.Service.Lightning.Consultant" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Certified.Commerce.Cloud.Digital.Developer.jpg" id=".cert-badge.Certified.Commerce.Cloud.Digital.Developer" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Accredited.Sales.Professional.jpg" id=".cert-badge.Accredited.Sales.Professional" style="display: none;">
        <img src="Images/Certificates/.cert-badge.Accredited.Presales.Professional.jpg" id=".cert-badge.Accredited.Presales.Professional" style="display: none;">--%>



       <%-- <div class="cert-badge-certified-commerce-cloud-digital-developer" id=".cert.badge.certified.commerce.cloud.digital.developer" style="display: none;"></div>
        <div class="cert-badge-certified-administrator"  id=".cert.badge.certified.administrator" style="display: none;"></div>
        <div class="cert-badge-certified-advanced-administrator"  id=".cert-badge.certified.advanced.administrator" style="display: none;"></div>
        <div class="cert-badge-certified-app-builder"  id=".cert.badge.certified.app.builder" style="display: none;"></div>
        <div class="cert-badge-certified-cpq-specialist"  id=".cert.badge.certified.cpq.specialist" style="display: none;"></div>
        <div class="cert-badge-certified-development-lifecycle-and-deployment-specialist" id=".cert.badge.certified.development.lifecycle.and.deployment.specialist" style="display: none;"></div>
        <div class="cert-badge-certified-field-service-lightning-consultant" id=".cert.badge.certified.field.service.lightning.consultant" style="display: none;"></div>
        <div class="cert-badge-certified-integration-architecture-specialist" id=".cert.badge.certified.integration.architecture.specialist" style="display: none;"></div>
        <div class="cert-badge-certified-marketing-cloud-email-specialist" id=".cert.badge.certified.marketing.cloud.email.specialist" style="display: none;"></div>
        <div class="cert-badge-certified-pardot-consultant" id=".cert.badge.certified.pardot.consultant" style="display: none;"></div>
        <div class="cert-badge-certified-pardot-user" id=".cert.badge.certified.pardot.user" style="display: none;"></div>
        <div class="cert-badge-certified-sales-consultant" id=".cert.badge.certified.sales.consultant" style="display: none;"></div>
        <div class="cert-badge-certified-service-consultant" id=".cert.badge.certified.service.consultant" style="display: none;"></div>
        <div class="cert-badge-accredited-presales-professional" id=".cert.badge.accredited.presales.professional" style="display: none;"></div>
        <div class="cert-badge-accredited-sales-professional" id=".cert.badge.accredited.sales.professional" style="display: none;"></div>
        <div class="cert-badge-certified-advanced-developer" id=".cert.badge.certified.advanced.developer" style="display: none;"></div>
        <div class="cert-badge-certified-application-architect" id=".cert.badge.certified.application.architect" style="display: none;"></div>
        <div class="cert-badge-certified-community-cloud-consultant" id=".cert.badge.certified.community.cloud.consultant" style="display: none;"></div>
        <div class="cert-badge-certified-data-architecture-and-management-specialist" id=".cert.badge.certified.data.architecture.and.management.specialist" style="display: none;"></div>
        <div class="cert-badge-certified-developer" id=".cert.badge.certified.developer" style="display: none;"></div>
        <div class="cert-badge-certified-identity-and-access-management-designer" id=".cert.badge.certified.identity.and.access.management.designer" style="display: none;"></div>
        <div class="cert-badge-certified-marketing-cloud-consultant" id=".cert.badge.certified.marketing.cloud.consultant" style="display: none;"></div>
        <div class="cert-badge-certified-marketing-cloud-social-specialist" id=".cert.badge.certified.marketing.cloud.social.specialist" style="display: none;"></div>
        <div class="cert-badge-certified-mobile-solutions-architecture-designer" id=".cert.badge.certified.mobile.solutions.architecture.designer" style="display: none;"></div>
        <div class="cert-badge-certified-programmer-i" id=".cert.badge.certified.programmer.i" style="display: none;"></div>
        <div class="cert-badge-certified-programmer-ii" id=".cert.badge.certified.programmer.ii" style="display: none;"></div>
        <div class="cert-badge-certified-sharing-and-visibility-designer" id=".cert.badge.certified.sharing.and.visibility.designer" style="display: none;"></div>
        <div class="cert-badge-certified-system-architect" id=".cert.badge.certified.system.architect" style="display: none;"></div>
        <div class="cert-badge-certified-technical-architect" id=".cert.badge.certified.technical.architect" style="display: none;"></div>--%>



        <script src="Scripts/fabric.min.js" type="text/javascript"></script>
        <script type="text/javascript">

            jQuery("select.image-picker").imagepicker({
                hide_select: false,
            });

            jQuery("select.image-picker.show-labels").imagepicker({
                hide_select: false,
                show_label: true,
            });

            jQuery("select.image-picker.limit_callback").imagepicker({
                limit_reached: function () { alert('We are full!') },
                hide_select: false
            });

            var container = jQuery("select.image-picker.masonry").next("ul.thumbnails");
            container.imagesLoaded(function () {
                container.masonry({
                    itemSelector: "li",
                });
            });

        </script>
    </form>

    <!-- Bootstrap core JavaScript -->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

</body>
</html>
