<%@ Page Title="" Language="C#" MasterPageFile="~/Adminp/Admin.Master" AutoEventWireup="true" CodeBehind="edits-Teacher.aspx.cs" Inherits="GroupProject.Adminp.edits_Teacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <!-- partial -->
      <div class="main-panel">        
        <div class="content-wrapper">
          <div class="row">
            <div class="col-md-4 grid-margin stretch-card">
              <div class="card">
                <div class="card-body">
                  <h4 class="card-title">ADD TEACHER</h4>
               
                     <asp:Label ID="lblmsg" runat="server" Cssclass="card-description alert alert-danger form-control"  Text="Enter alls Fields"></asp:Label>     
                    
                
                  <div class="forms-sample">
                    <div class="form-group">
                      <label for="exampleInputUsername1">Teacher Name</label>
                   
                        <asp:TextBox ID="txtname" Cssclass="form-control mt-2"  placeholder="Enter fullname" runat="server"></asp:TextBox>   
                                            								
                          </div>
                 
                    <div class="form-group">
                      <label for="exampleInputPassword1">StaffID</label>
                    	   <asp:TextBox ID="txtid" Cssclass="form-control mt-2"  placeholder="Enter Index Number" type="text" runat="server"></asp:TextBox>   
                                                    
                          </div>
                    <div class="form-group">
                      <label for="exampleInputConfirmPassword1">Gender</label>
         <label><i class="fa fa-venus"></i> Gender</label>
                                            <asp:DropDownList ID="drpgender" Cssclass="form-control mt-2" type="text"  runat="server">
                                                <asp:ListItem>Select Gender</asp:ListItem>
                                                <asp:ListItem>Male</asp:ListItem>
                                                <asp:ListItem>Female</asp:ListItem>
                                            </asp:DropDownList>
                         </div>
                          
             

                           <div class="form-group">
                      <label for="exampleInputConfirmPassword1">Username</label>
            <asp:TextBox ID="txtuser" type="username" Cssclass="form-control mt-2" placeholder="Enter Username"   runat="server"></asp:TextBox>
                                            
                         </div>
                          <div class="form-group">
                      <label for="exampleInputConfirmPassword1">Password</label>
          <asp:TextBox ID="txtPass" Type="password" Cssclass="form-control mt-2" placeholder="Enter Password"   runat="server"></asp:TextBox>
              
                         </div>

                           <asp:Button ID="Button1" runat="server"  class="btn btn-primary me-2" Text="Submit" OnClick="btnsubmit_Click" />
                            <asp:Button ID="Button2" runat="server"  class="btn btn-primary me-2" Text="Update" OnClick="btnupdate_Click"  />
                             <asp:Button ID="Button3" runat="server"  class="btn btn-primary me-2" Text="Delete" OnClick="btndelete_Click"/>
                   
                  </div>
                </div>
              </div>
            </div>
            <div class="col-md-8 grid-margin stretch-card">
         <div class="card">
                <div class="card-body">
                  <h4 class="card-title">TEACHER</h4>
                    					
                    <div class="table-responsive">
           
                        <div class="form-outline m-2">
                               
                            <asp:TextBox ID="Txtsearchk"  text="Search with Student ID." Cssclass="form-control" Style="width:25rem;" runat="server"></asp:TextBox>
                              <asp:Button ID="btnsearch" runat="server"  class="btn btn-primary mt-1" Text="Search"   />
                           
                               <asp:Button ID="btnedits" runat="server"  class="btn btn-primary mt-1" Text="Edits" OnClick="btnedits_Click" />
                 
                            </div>
                 
                 
            <asp:GridView ID="GridView" runat="server" Cssclass="table-responsive" AutoGenerateColumns="False" CellPadding="30" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
          <Columns>
                                  <asp:BoundField DataField="Name" ItemStyle-CssClass=""  HeaderText="Name"/>
                  <asp:BoundField DataField="IDNumber" ItemStyle-CssClass="" HeaderText="StaffID"/>
                    <asp:BoundField DataField="Gender" ItemStyle-CssClass="" HeaderText="Gender"/>
                    <asp:BoundField DataField="username" ItemStyle-CssClass="" HeaderText="username"/>
                  <%--  <asp:BoundField DataField="password" ItemStyle-CssClass=""  HeaderText="password"/>
               --%>
      
                 
          </Columns>
               <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
      </asp:GridView>
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
