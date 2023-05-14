<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="GroupProject.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../../vendors/feather/feather.css"/>
  <link rel="stylesheet" href="../../vendors/mdi/css/materialdesignicons.min.css"/>
  <link rel="stylesheet" href="../../vendors/ti-icons/css/themify-icons.css"/>
  <link rel="stylesheet" href="../../vendors/typicons/typicons.css"/>
  <link rel="stylesheet" href="../../vendors/simple-line-icons/css/simple-line-icons.css"/>
  <link rel="stylesheet" href="../../vendors/css/vendor.bundle.base.css"/>
  <!-- endinject -->
  <!-- Plugin css for this page -->
  <!-- End plugin css for this page -->
  <!-- inject:css -->
  <link rel="stylesheet" href="../../css/vertical-layout-light/style.css"/>
  <!-- endinject -->
  <link rel="shortcut icon" href="../../images/uew.png" />
</head>
<body>
  <form id="form1" runat="server">
    <div>
    <div class="container-scroller">
    <div class="container-fluid page-body-wrapper full-page-wrapper">
      <div class="content-wrapper d-flex align-items-center auth px-0">
        <div class="row w-100 mx-0">
          <div class="col-lg-4 mx-auto">
            <div class="auth-form-light text-left py-5 px-4 px-sm-5">
              <div class="brand-logo">
                <img src="../../images/uew.png" alt="logo"/>
              </div>
              <h4>Hello! let's get started</h4>
                <div class="form-group mt-3">
    <asp:Label  ID="lblmsg" runat="server" Text="Sign in to continue" Cssclass="alert alert-danger btn-block text-sm-start" style="height: 3.5rem;" ></asp:Label>
                  
                </div>
          
           
              <div class="pt-3">
       
                <div class="form-group">
                     
                       <asp:TextBox ID="txtuser" Cssclass="form-control form-control-lg" runat="server" placeholder="Enter username"></asp:TextBox>
              
                </div>
                <div class="form-group">
   <asp:TextBox ID="txtpass" Type="password" Cssclass="form-control form-control-lg" runat="server" placeholder="Enter password" ></asp:TextBox>
               
                </div>
                <div class="mt-3">
                         <asp:Button ID="Button1" runat="server" Text="SIGN IN" Cssclass="btn btn-block btn-primary btn-lg font-weight-medium auth-form-btn"  />
                  
                 
                </div>
               
                <div class="mb-2">
                 
                </div>
            
              </div>
            </div>
          </div>
        </div>
      </div>
      <!-- content-wrapper ends -->
    </div>
    <!-- page-body-wrapper ends -->
  </div>
  <!-- container-scroller -->
  <!-- plugins:js -->

    </div>

              <!-- container-scroller -->
  <!-- plugins:js -->
  <script src="../../vendors/js/vendor.bundle.base.js"></script>
  <!-- endinject -->
  <!-- Plugin js for this page -->
  <script src="../../vendors/bootstrap-datepicker/bootstrap-datepicker.min.js"></script>
  <!-- End plugin js for this page -->
  <!-- inject:js -->
  <script src="../../js/off-canvas.js"></script>
  <script src="../../js/hoverable-collapse.js"></script>
  <script src="../../js/template.js"></script>
  <script src="../../js/settings.js"></script>
  <script src="../../js/todolist.js"></script>
    </form>
</body>
</html>
