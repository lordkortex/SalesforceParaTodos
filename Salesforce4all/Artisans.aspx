<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Artisans.aspx.vb" Inherits="Salesforce4all.Artisans" %>
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

<body onload="javascript:codeAddress();">
    <form id="form1" runat="server">


        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

      
        <!-- Navigation -->
        <nav class="navbar fixed-top navbar-expand-lg navbar-dark bg-dark fixed-top">
          <div class="container">
            <a class="navbar-brand" href="Default.aspx">Salesforce4All.com</a>
            <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
              <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarResponsive">
              <ul class="navbar-nav ml-auto">
                <li class="nav-item active">
                  <a class="nav-link" href="about.html">About</a>
                </li>
              </ul>
            </div>
          </div>
        </nav>


        



        <!-- Page Content -->
        <div class="container">

            <%--<h1 class="my-4"></h1>--%>

             <div class="row" style="margin-top:50px;margin-bottom:50px" >
                <div class="col-lg-6">
                    <h2>ARTISAN CONSULTING</h2>
                    <p>Welcome to the new way to generate your certificate logo In association with ARTISAN CONSULTING.</p>
                    <p>A certificate list and points score can also be accessed via Artisan Hub's Certified Professional Ranking and Regional Statistics Service.</p>
                    <p>Click   <a href="https://about.artisans.com.au/salesforce-certified-professional-artisan-hub-launch/#.WjvFxnmQzIU" target="_blank">here </a> for more information.</p>
                </div>
                <div class="col-lg-6">
                    <%--<img class="img-fluid rounded" src="http://placehold.it/700x450" alt="">--%>
                     <img class="img-fluid rounded" src="" alt="">
                    <a href="https://about.artisans.com.au/salesforce-certified-professional-artisan-hub-launch/#.WjvFxnmQzIU" target="_blank"> <img border="0" alt="Artisans" src="Images/Artisans.jpg" class="img-fluid rounded" > </a>
                </div>
            </div>

      

             <div class="card my-4">
                        <h5 class="card-header-salesforce">Step 1 : Choose your favorite design !!!</h5>
                        <div class="card-body">
                            <div class="picker">
                                <select runat="server" title="Selecciona tu imagen preferida" class="image-picker show-labels show-html" id="imageSelected"  style="display: none">
                                    <option data-img-src='Images/12/header-bg-1.png' value='header-bg-1'>Cabin</option>
                                    <option data-img-src='Images/12/header-bg-2.png' value='header-bg-2'>Morning</option>
                                    <option data-img-src='Images/12/header-bg-3.png' value='header-bg-3'>Sun</option>
                                    <option data-img-src='Images/12/header-bg-4.png' value='header-bg-4'>Street</option>

                                    <option data-img-src='Images/12/header-bg-5.png' value='header-bg-5'>Lake</option>
                                    <option data-img-src='Images/12/header-bg-6.png' value='header-bg-6'>Universe</option>
                                    <option data-img-src='Images/12/header-bg-7.png' value='header-bg-7'>Autumn</option>
                                    <option data-img-src='Images/12/header-bg-8.png' value='header-bg-8'>Fjord</option>

                                    <option data-img-src='Images/12/header-bg-9.png' value='header-bg-9'>Hill</option>
                                    <option data-img-src='Images/12/header-bg-10.png' value='header-bg-10'>Immensity</option>
                                    <option data-img-src='Images/12/header-bg-11.png' value='header-bg-11'>Route</option>
                                    <option data-img-src='Images/12/header-bg-12.png' value='header-bg-12'>Calm</option>

                                    <option data-img-src='Images/12/header-bg-13.png' value='header-bg-13'>Beach</option>
                                    <option data-img-src='Images/12/header-bg-14.png' value='header-bg-14'>Sun Flower</option>
                                    <option data-img-src='Images/12/header-bg-15.png' value='header-bg-15'>Red Carpet</option>
                                    <option data-img-src='Images/12/header-bg-16.png' value='header-bg-16'>Bridge</option>

                                    <option data-img-src='Images/12Trailhead/header-bg-1.png' value='header-bg-t1'>Forest</option>
                                    <option data-img-src='Images/12Trailhead/header-bg-2.png' value='header-bg-t2'>Sunrise</option>
                                    <option data-img-src='Images/12Trailhead/header-bg-3.png' value='header-bg-t3'>Morning</option>
                                    <option data-img-src='Images/12Trailhead/header-bg-4.png' value='header-bg-t4'>Night</option>
               

                                </select>
                            </div>
                        </div>
              <%--          <asp:Button class="btn btn-primary" type="button" ID="Buscar" runat="server" Text="Generate Image" OnClientClick="ga('send', 'event', 'PDF Downloads', 'Click', 'SEO For Beginners');" />
             --%>               
                    </div>

   
                                 <div class="card my-4">
                        <h5 class="card-header-salesforce">Step 2: Search your salesforce account id</h5>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <ul class="list-unstyled mb-0">
                                       <%-- <li>
                                                <asp:Label ID="lblMessage1" runat="server"></asp:Label>
                                        </li>--%>
                                        <li>
                                                  <b> Go ahead : </b>  This id is necesary to get the certificates . Follow this instructions:
                                            <br>
                                        </li>
                                        <br>
                                        <li>
                                                <p class="card-text"><b>1.</b> Go to official web salesforce credential <a target="_blank" href="https://trailhead.salesforce.com/credentials/verification">Verification Site</a></p>
                                        </li>
                                        <li>
                                                <p class="card-text"><b>2.</b> On <b>Verify a Salesforce Certified Professional</b> section. Then submit your <b>full name or email associated to webassesor</b> </p>
                                        </li>
                                        <li>
                                                <p class="card-text"><b>3.</b> Click on <b>Search button</b>.</p>
                                        </li>
                                        <li>
                                                <p class="card-text"><b>4.</b> Please complete the ReCaptcha. <b>I´m not a robot</b></p>
                                        </li>
                                          <li>
                                                <p class="card-text"><b>5.</b> Click on  <b>Show credentials</b></p>
                                        </li>
                                          <li>
                                                <p class="card-text"><b>6.</b> Click on  <b>Print Preview</b></p>
                                        </li>
                                          <li>
                                                <p class="card-text"><b>7.</b> It will open a new window with a url like this  <b><a target="_blank" href="https://trailhead.salesforce.com/credentials/certification-detail-print?searchString=003G000002S9aeZIAR">Verification Site</a></b></p>
                                        </li>
                                         <li>
                                                <p class="card-text"><b>8.</b> Copy the searchString value at the end of url, it look like this:   <b>1RKVx8wH2FPaPqe6hKA6%2FL3UlBFlTXO6bNEIZLkpqvmycVnnROWZuzeOnIaTCl1M</b></p>
                                        </li>
                                         <li>
                                                <p class="card-text"><b>9. </b> Use this salesforce id  in next step to get your beatiful image.</p>
                                        </li>
                                         <br>
                                        <li>
                                            <!--<iframe width="420" height="315" src="https://www.youtube.com/embed/hIC8P_KZ8Js" frameborder="0" gesture="media" allowfullscreen></iframe>-->
                                            <iframe width="560" height="315" src="https://www.youtube.com/embed/iQV62TWIO9Y" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                                        </li>
                                    </ul>
                                </div>
                              
                            </div>
                        </div>
                    </div>


            
             <div class="card my-4">
                        <h5 class="card-header-salesforce">Step 3 : Search your salesforce certificates by your ID associated to your salesforce account on webassesor</h5>
                        <div class="card-body">
                            <div class="row">
                                
                                <div class="col-lg-6">
                                    <ul class="list-unstyled mb-0">
                                        <li>
                                            <b>Email: </b> 
                                        </li>
                                        <li>
                                           <asp:TextBox runat="server" ID="email" class="form-control" placeholder="Example: Email@domain.com..."></asp:TextBox>
                                        </li>
                                    </ul>
                                </div>
                                 <div class="col-lg-6">
                                    <ul class="list-unstyled mb-0">
                                        <li>
                                             <b>Id Salesforce: Follow instructions in Step 2 to get this value</b> 
                                        </li>
                                        <li>
                                           <asp:TextBox runat="server" ID="idSalesforce" class="form-control" placeholder="Example: 1RKVx8wH2FPaPqe6hKA6%2FL3UlBFlTXO6bNEIZLkpqvmycVnnROWZuzeOnIaTCl1M"></asp:TextBox>

                                        </li>
                                    </ul>
                                </div>
                               
                            </div>
                            <br />
                             <span class="input-group-btn">
                                <asp:Button  BackColor="Tomato"  class="btn btn-primary" type="button" ID="Buscar" runat="server" Text="Generate Image" OnClientClick="ga('send', 'event', 'PDF Downloads', 'Click', 'SEO For Beginners');" />
                                <label for="male" id="busqueda" style="display:none ">Buscando ...</label>
                             </span>
                             <br />
                             <asp:Label ID="LabelInputMessageValidation" runat="server"  ForeColor ="Red" Font-Bold="true"  ></asp:Label>
                            
                        </div>
                    </div>


             <div id="drawZoneNoResuts" style ="display:none" >

                    <div class="card my-4">
                        <h5 class="card-header-salesforce">Step 4: Results</h5>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-6">
                                    <ul class="list-unstyled mb-0">
                                       <%-- <li>
                                                <asp:Label ID="lblMessage1" runat="server"></asp:Label>
                                        </li>--%>
                                        <li>
                                                  <b> No search Results : </b>  No problem !! . Follow this instructions:
                                            <br>
                                        </li>
                                        <br>
                                        <li>
                                                <p class="card-text"><b>1.</b> Go to your webassessor account on  <a target="_blank" href="https://www.webassessor.com">WebAssesor</a></p>
                                        </li>
                                        <li>
                                                <p class="card-text"><b>2.</b> Set verification Opt-In value to <b>YES</b> </p>
                                        </li>
                                        <li>
                                                <p class="card-text"><b>3.</b> Copy <b>email address associated to your salesforce account</b>.</p>
                                        </li>
                                        <li>
                                                <p class="card-text"><b>4.</b> Paste email on search   <a target="_blank" href="http://certification.salesforce.com/verification">Salesforce Verification</a></p>
                                        </li>
                                          <li>
                                                <p class="card-text"><b>5.</b> Search again on this site and get your logo !!!</p>
                                        </li>
                                         <br>
                                        <li>
                                            <iframe width="420" height="315" src="https://www.youtube.com/embed/hIC8P_KZ8Js" frameborder="0" gesture="media" allowfullscreen></iframe>
                                        </li>
                                    </ul>
                                </div>
                                <div class="col-lg-6">
                                    <ul class="list-unstyled mb-0">
                                        <li>
                                                <asp:Label ID="lblMessage3" runat="server"></asp:Label>
                                        </li>
                                        <li>
                                                <asp:Label ID="Label4" runat="server"></asp:Label>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                 </div>

            <div id="drawZone" style ="display:none" >

                  <div class="card my-4">
                        <h5 class="card-header-salesforce">Step 5: Results</h5>
                        <div class="card-body">
                            <div class="row">
                                 <div class="col-lg-6">
                                    <ul class="list-unstyled mb-0">
                                        <li>
                                            <p>Congratulations! You have successfully completed the certification exams to become a Salesforce Certified.Welcome to the Salesforce worldwide community of Certified Professionals!   </p>
                                        </li>
                                    </ul>
                                </div>
                              
                                <div class="col-lg-6">
                                    <ul class="list-unstyled mb-0">
                                        <li>
                                            <b>Name: </b> 
                                                <asp:Label ID="lblName" runat="server"></asp:Label>
                                        </li>
                                        <li>
                                            <b>City: </b> 
                                                <asp:Label ID="lblCity" runat="server"></asp:Label>
                                        </li>
                                        <li>
                                            <b>Country: </b> 
                                                <asp:Label ID="lblCountry" runat="server"></asp:Label>
                                        </li>
                                        <li>
                                            <b>State: </b> 
                                                <asp:Label ID="lblState" runat="server"></asp:Label>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>


                  <div class="card my-4">
                        <h5 class="card-header-salesforce">Step 3: Iframe</h5>
                        <div class="card-body">
                            <div class="row">
                                 <div class="col-lg-12">
                                    <ul class="list-unstyled mb-0">
                                        <li>
                                            <p>Now you can use an iframe on your website, now you can always keep up to date your cert logo!. Background parameter is a value from 0 to 14 </p>
                                        </li>
                                    </ul>
                                </div>
                                <div class="col-lg-12">
                                    <ul class="list-unstyled mb-0">
                                        <li>
                                            <p><b><asp:Literal ID="LiteralIframe" runat="server" ></asp:Literal></b></p>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>



                    <div class="row">
                        <div id="container">
                            <canvas id="c" width="1200" height="320"></canvas>
                        </div>
                    </div>



                    <!-- Call to Action Section -->
                    <div class="row mb-4" style="margin-top: 20px">
                          <div class="col-md-8">
                            <div class="row">
                            <div class="col-lg-2 col-sm-4 mb-4">
                              <img class="img-fluid" src="Images/browsers/logo-firefox.png" alt="">
                            </div>
                            <div class="col-lg-2 col-sm-4 mb-4">
                              <img class="img-fluid" src="Images/browsers/logo-opera.png" alt="">
                            </div>
                            <div class="col-lg-2 col-sm-4 mb-4">
                              <img class="img-fluid" src="Images/browsers/logo-safari.png" alt="">
                            </div>
                            <div class="col-lg-2 col-sm-4 mb-4">
                              <img class="img-fluid" src="Images/browsers/logo-chrome.png" alt="">
                            </div>
                          </div>
                          </div>
                        <div class="col-md-4">
                              <p>Choose Chrome,Firefox ,Opera or Safari Browser to save your logo  certificate.</p>
                            <a  class="btn btn-primary" href="#" onclick="saveImg();" style="width:350px " >Save Image</a>
                        </div>
                    </div>

            </div>
          

           

           


            <!-- Features Section -->
            <div class="row" style="margin-top:50px;margin-bottom:50px" >
                <div class="col-lg-6">
                    <h2>Modern  Features</h2>
                    <p>The Modern  template is an image which could be use on:</p>
                    <ul>
                        <li>Footer template on your Email</li>
                        <li>Background image on your linkedIn profile </li>
                        <li>Header page on your personal professiona site</li>
                    </ul>
                    <p>Whatever your role, earning credentials from Salesforce shows that you have the ability to help transform companies by applying your knowledge to solve real-world challenges. The result? Salesforce-certified professionals aren't just in demand - they're increasingly indispensable.</p>
                </div>
                <div class="col-lg-6">
                    <%--<img class="img-fluid rounded" src="http://placehold.it/700x450" alt="">--%>
                     <img class="img-fluid rounded" src="Images/Email.jpg" alt="">
                </div>
            </div>
            <!-- /.row -->

              <h2>Many users have already used it in their Linked In background profile</h2>
                    <p></p>


              <div class="row"  style="margin-top:50px;margin-bottom:50px" >
                
                    <div class="col-md-3 col-sm-6 mb-4">
                      <a href="#">
                        <img class="img-fluid" src="/Images/LinkedIn/Linked4.png" alt="">
                      </a>
                    </div>

                    <div class="col-md-3 col-sm-6 mb-4">
                      <a href="#">
                        <img class="img-fluid" src="/Images/LinkedIn/Linked3.png" alt="">
                      </a>
                    </div>

                    <div class="col-md-3 col-sm-6 mb-4">
                      <a href="#">
                        <img class="img-fluid" src="/Images/LinkedIn/Linked2.png" alt="">
                      </a>
                    </div>

                    <div class="col-md-3 col-sm-6 mb-4">
                      <a href="#">
                        <img class="img-fluid" src="/Images/LinkedIn/Linked1.png" alt="">
                      </a>
                    </div>

                  </div>


              <h2>My Profile</h2>
                    <p></p>

             <!-- Content Row -->
              <div class="row" style="margin-top:50px">
                <div class="col-lg-4 mb-4">
                  <div class="card h-50">
                    <h3 class="card-header" style="text-align:center">Email</h3>
                    <div class="card-body" style="width:150px;height:150px;text-align:center;margin-left:100px">
                      <img class="card-img-top" src="Images/Social/12/gmail.png" alt="">
                    </div>
                    <ul class="list-group list-group-flush">
                      <li class="list-group-item"> <a href="#">lordkortex@gmail.com</a></li>
                    </ul>
                  </div>
                </div>
                 <div class="col-lg-4 mb-4">
                  <div class="card h-50">
                    <h3 class="card-header" style="text-align:center">Skype</h3>
                    <div class="card-body" style="width:150px;height:150px;text-align:center;margin-left:100px">
                      <img class="card-img-top" src="Images/Social/12/skype.png" alt="">
                    </div>
                    <ul class="list-group list-group-flush">
                      <li class="list-group-item"> <a href="#">Jhon Fredy Cortes Gaspar</a></li>
                    </ul>
                  </div>
                </div>
                 <div class="col-lg-4 mb-4">
                  <div class="card h-50">
                    <h3 class="card-header" style="text-align:center">LinkedIn</h3>
                    <div class="card-body" style="width:150px;height:150px;text-align:center;margin-left:100px">
                      <img class="card-img-top" src="Images/Social/12/linkedin.png" alt="">
                    </div>
                    <ul class="list-group list-group-flush">
                      <li class="list-group-item">  <a target="_blank" href="https://www.linkedin.com/in/johncortes57">LinkedIn Profile</a></li>
                    </ul>
                  </div>
                </div>
              </div>


               <a href="https://twitter.com/share?ref_src=twsrc%5Etfw" class="twitter-share-button" data-show-count="false">Tweet</a><script async src="https://platform.twitter.com/widgets.js" charset="utf-8"></script>

            <hr>
        </div>
        <!-- /.container -->







         <!-- Footer -->
    <footer class="py-5 bg-dark">
      <div class="container">
        <p class="m-0 text-center text-white">Copyright &copy; Salesforce 4 All 2017</p>
      </div>
      <!-- /.container -->
    </footer>

  

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
       <img src="Images/Certificates/.cert-badge.Certified.Field.Service.Lightning.Consultant.jpg" id="Salesforce Certified Field Service Lightning Consultant" style="display: none;">
      
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
