<%@ Page Title="" Language="C#" MasterPageFile="~/Teacher/Teachers-Dashboard.Master" AutoEventWireup="true" CodeBehind="CourseObjectivesPage.aspx.cs" Inherits="GroupProject.CourseObjectivesPage" %>
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
                  <h4 class="card-title">COURSE OBJECTIVES</h4>
               
                     <asp:Label ID="lblmsg" runat="server" Cssclass="card-description alert alert-danger form-control"  Text="Enter alls Fields"></asp:Label>     
                    
                
                  <div class="forms-sample">
                    <div class="form-group">
                      <label for="exampleInputUsername1">COURSE OBJECTIVES</label>
                   
                       <asp:TextBox ID="txtCourse" Cssclass="form-control"  placeholder="Enter Course Title" runat="server"></asp:TextBox>    
										
                          </div>
                    <div class="form-group">
                      <label for="exampleInputEmail1">COURSE TITLE</label>
                         <asp:TextBox ID="txtCode" Cssclass="form-control"  placeholder="Enter Course code" runat="server"></asp:TextBox>    
									
                    </div>
                    <div class="form-group">
                      <label for="exampleInputPassword1">AIMS AND OBJECTIVES</label>
                    	
                 <asp:TextBox ID="txtab" Cssclass="form-control mt-2" type="text" Style="height:90px;" placeholder="Aims and objectives of the course" TextMode="MultiLine"  runat="server"></asp:TextBox>
									
                          </div>
                    <div class="form-group">
                      <label for="exampleInputConfirmPassword1">COURSE OBJECTIVES</label>
                    <asp:TextBox ID="TxtDescrip" Cssclass="form-control mt-2" Style="height:120px;" placeholder="Enter Description Here"  TextMode="MultiLine" runat="server"></asp:TextBox>

                         </div>
                
                           <asp:Button ID="Button1" runat="server"  class="btn btn-primary me-2" Text="Submit" OnClick="btnsubmit" />
                            <asp:Button ID="Button2" runat="server"  class="btn btn-primary me-2" Text="Update" OnClick="btnupdate"  />
                             <asp:Button ID="Button3" runat="server"  class="btn btn-primary me-2" Text="Delete" OnClick="btndelete"/>
                   
                  </div>
                </div>
              </div>
            </div>
            <div class="col-md-8 grid-margin stretch-card">
         <div class="card">
                <div class="card-body">
                  <h4 class="card-title">Course Obejectives</h4>
                    					
                    <div class="table-responsive">
           
                        <div class="form-outline m-2">
                               
                            <asp:TextBox ID="Txtsearchk"  text="Search with Course Code" Cssclass="form-control" Style="width:25rem;" runat="server"></asp:TextBox>
                              <asp:Button ID="btnsearch" runat="server"  class="btn btn-primary mt-1" Text="Search" OnClick="btnsearch_Click"  />
                              <asp:Button ID="btnedits" runat="server"  class="btn btn-primary mt-1" Text="Edits" OnClick="btnedits_Click" />
                 
                            </div>
                 
                 
            <asp:GridView ID="GridView" runat="server" Cssclass="table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
          <Columns>
              
      
                    <asp:BoundField DataField="courseCode" ItemStyle-CssClass=""  HeaderText="CourseCode"/>
                    <asp:BoundField DataField="CourseTitle" ItemStyle-CssClass="" HeaderText="Course Title"/>
                    <asp:BoundField DataField="Objectives" ItemStyle-CssClass="" HeaderText="Objectives"/>
                    <asp:BoundField DataField="CDescription" ItemStyle-CssClass=""  HeaderText="Course Description"/>
               
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
