<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GroupProject.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7/jquery.min.js" type="text/javascript"></script>  
              <link  rel="stylesheet" href="css/mdb.min.css"/>
              <script  type="text/javascript" src="js/mdb.min.js"></script>

        <script>
            function StartTest(popUpPage) {
                window.open(popUpPage, 'null', 'toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=0,fullscreen=yes');
            }  
        </script>
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
    <form id="form2" runat="server">
   <div style=" text-align :center; width:100%" >
                
                        <table width="1000"  cellpadding="10" style="height: 272px" class="shadow-3" >  
                            <tr>  
                                <td style="text-align:center;">  
                                    <b>  
                                       <asp:Label ID="lbstatus" runat="server" 
                                       Font-Bold="True" 
                                       Font-Size="16pt" 
                                        >Welcome to Group name online Quiz Examination</asp:Label>  
                                      </b>  
                                </td>  
                            </tr>  
                            <tr>  
                                <td style="text-align:center;"><b>Start Quiz</b></td>  
                            </tr>  
                            <tr>  
                              
                                <td style="text-align: center;">  
                                    <asp:Button ID="btnStartTest" Text="Start Quiz" runat="server" 
                                        OnClientClick="return StartTest('default2.aspx');"
                                          CssClass="btn btn-primary" />  

                                      </td>  
                            </tr>  
                        </table>  
                  
            </div>  
    </form>
</body>
</html>
