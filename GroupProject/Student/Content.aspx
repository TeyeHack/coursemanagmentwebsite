<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMD.Master" AutoEventWireup="true" CodeBehind="Content.aspx.cs" Inherits="GroupProject.Student.Content" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <!-- partial -->
      <div class="main-panel">        
        <div class="content-wrapper">
          <div class="row">
    
            <div class="col-md-12 grid-margin stretch-card">
         <div class="card">
               <asp:Label ID="lbltitle" class="card-header" runat="server" Text="Label"></asp:Label>
                
                <div class="card-body">
                  <h4 class="card-title">Download Slides and Resources</h4>
                    		        <asp:Label ID="lbldsmain" class="card-text" runat="server" Text="Course Description"></asp:Label>

                       <h4 class="card-title">Aims and Objectives Of The Course</h4>
                 
                    
                 
 
                    <asp:Label ID="lblaims" class="card-text" runat="server" Text="aims"></asp:Label>
 			
                    <div class="table-responsive">
           
                        <div class="form-outline m-2">
                               
                            <asp:TextBox ID="Txtsearchk"  text="Search with Week no" Cssclass="form-control" Style="width:25rem;" runat="server"></asp:TextBox>
                              <asp:Button ID="btnsearch" runat="server"  class="btn btn-primary mt-1" Text="Search"   />
                           
                    
                 
                            </div>
                 
                 
            <asp:GridView ID="GridView" runat="server" Cssclass="table-responsive" AutoGenerateColumns="False" CellPadding="20" ForeColor="#333333" GridLines="None" OnRowCommand="GridView_RowCommand">
                <AlternatingRowStyle BackColor="White" />
          <Columns>
              
            <asp:BoundField DataField="Week" ItemStyle-CssClass=""  HeaderText="Week"/>
                    <asp:BoundField DataField="Topic" ItemStyle-CssClass="" HeaderText="Topic"/>

                    <asp:BoundField DataField="Description" ItemStyle-CssClass=""  HeaderText="Description"/>
                 <asp:TemplateField HeaderText="File">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("Documents") %>' CommandName="Documents" Text='<%# Eval("Documents") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                 
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
