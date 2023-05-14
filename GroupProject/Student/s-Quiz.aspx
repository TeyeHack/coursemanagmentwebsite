<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMD.Master" AutoEventWireup="true" CodeBehind="s-Quiz.aspx.cs" Inherits="GroupProject.Student.s_Quiz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <!-- partial -->
      <div class="main-panel">        
        <div class="content-wrapper">
          <div class="row">
    
            <div class="col-md-12 grid-margin stretch-card">
         <div class="card">
                <div class="card-body">
                  <h4 class="card-title">Quiz</h4>
                    					
                    <div class="table-responsive">
           
                        <div class="form-outline m-2">
                            <asp:Label ID="Label1" runat="server" Text="Quiz Instructions"></asp:Label>
                            <a   class="btn btn-primary mt-1"  href="../Default.aspx" >Start Quiz</a> 
                           
                    
                 
                            </div>
                 
                 
     
           </div>
                    </div>
                   </div>
                
                </div>
              </div>
            </div>
       
     
        <!-- content-wrapper ends -->
        <!-- partial:../../partials/_footer.html -->
       <footer class="footer">
          <div class="d-sm-flex justify-content-center justify-content-sm-between">
            <span class="text-muted text-center text-sm-left d-block d-sm-inline-block">Premium <a href="#" target="_blank">Bootstrap admin template</a> from BootstrapDash.</span>
            <span class="float-none float-sm-right d-block mt-1 mt-sm-0 text-center">Copyright © 2022. All rights reserved.</span>
          </div>
        </footer>

        <!-- partial -->
      </div>
      <!-- main-panel ends -->
    </div>
    <!-- page-body-wrapper ends -->
  </div>
  <!-- container-scroller -->

</asp:Content>
