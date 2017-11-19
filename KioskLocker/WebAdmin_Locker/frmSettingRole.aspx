<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Master/MasterPage.Master" CodeFile="frmSettingRole.aspx.vb" Inherits="frmSettingRole" %>
<%@ Register src="ucAuthorizeSelector2.ascx" tagname="ucAuthorizeSelector2" tagprefix="uc2" %>
<%@ Register src="ucAuthorizeSelector3.ascx" tagname="ucAuthorizeSelector3" tagprefix="uc3" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="HeaderContainer" ContentPlaceHolderID="HeaderContainer" runat="server">
      <!-- page stylesheets -->
      <link rel="stylesheet" type="text/css" href="vendor/checkbo/src/0.1.4/css/checkBo.min.css" />
      <link rel="stylesheet" href="vendor/sweetalert/dist/sweetalert.css" />
      <link rel="stylesheet" href="Styles/jquery.dataTables.min.css" />
      <!-- end page stylesheets -->

      <style type="text/css">
            tbody tr td
            {
                font-size:16px;
                }
            .badge
            {
                margin-left:5px;
                }
            .icon
            {
                margin-right:10px;
                }
           .numeric
           {
               text-align:center;
               }
           .user-item
           {
               padding:5px;
               margin-right:20px;
               margin-bottom:10px;
               display:inline-block;
               }
           .user-item i
           {
               margin-left:10px;
               margin-right:10px;
               }
           .user-item a
           {
                margin-left:10px;
                padding-top:3px;
                padding-bottom:3px;
                padding-left:6px;
                padding-right:6px;
               }
           .user-item a:hover
           {
                color:green;
                background-color:White;
               }
          
           .sweet-alert {
          text-align:left;
          width:400px;
          top:0px;
          margin-top:unset;
          bottom:0px;
          border-radius:unset;
          }

        .sweet-alert input[type="search"] {       
        width:100%;
        }

        .sweet-alert input{
        border-radius:0;
        font-size:16px;
        margin-bottom:15px;   
        margin-top:15px;   
        }
        
        /*.sweet-alert input[type="submit"] {
        width:unset;
        }*/

        .dataTables_wrapper .dataTables_filter {
        float:unset;
        }

        .dataTables_wrapper .dataTables_filter input {
        margin-left:unset;
        }

          .dataTables_filter label {
           display:inline;          
          }
        .dataTables_filter label input {
              Width:100%;
        }


      </style>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-title">
        <div class="title">Master Data > User Authorization > Role</div>
    <%--    <div class="sub-title">Manage user role to specify accessibility template</div>--%>
    </div>
<asp:UpdatePanel ID="udpList" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlList" runat="server" CssClass="card bg-white" Visible="True">
        <div class="card-header">
            Found : <asp:Label ID="lblTotalList" runat="server"></asp:Label> Role(s)
        </div>
        <div class="card-block">
            <div class="no-more-tables">
            <table class="table table-bordered m-b-0">
              <thead>
                <tr>
                  <th rowspan="2">Role</th>
                  <th colspan="2">Authorization Zone</th>
                  <th rowspan="2">Member(s)</th>
                  <th rowspan="2" id="ColEdit" runat="server">Edit</th>
                  <th rowspan="2" id="ColDelete" runat="server">Delete</th>
                </tr>
                <tr>
                    <th>Admin Web</th>
                    <th>Kiosk' Staff Console</th>
                </tr>
              </thead>
              <tbody>
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                 <tr>                 
                  <td data-title="Role" class="text-primary" id="td" runat="server"><i class="icon icon-users"></i> <asp:Label ID="lblRoleName" runat="server"></asp:Label></td>
                  <td data-title="Admin Web Available" class="numeric"><asp:Label ID="lblAdmin" runat="server"></asp:Label></td>
                  <td data-title="Staff Console Available" class="numeric"><asp:Label ID="lblStaffConsole" runat="server"></asp:Label></td>
                  <td data-title="Member" class="numeric"><asp:Label ID="lblMember" runat="server"></asp:Label></td>
                  <td data-title="Edit" class="numeric" id="ColEdit" runat="server"><asp:Button CssClass="btn btn-success" ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" /></td>
                  <td data-title="Delete" class="numeric" id="ColDelete" runat="server"><asp:Button CssClass="btn btn-danger" ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" /></td>               
                </tr>
                 <ajaxToolkit:ConfirmButtonExtender ID="cfmDelete" runat="server" TargetControlID="btnDelete" />
            </ItemTemplate>
        </asp:Repeater>
              </tbody>
            </table>
            </div>
            
            <div class="row m-t">
                <asp:LinkButton CssClass="btn btn-primary btn-icon loading-demo mr5 btn-shadow" ID="btnAdd" runat="server">
                  <i class="fa fa-plus-circle"></i>
                  <span>Add new role</span>
                </asp:LinkButton>
            </div>
          </div>
    </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="udpEdit" runat="server">
    <ContentTemplate>

        <asp:Panel ID="pnlEdit" runat="server"  CssClass="card bg-white">
            <div class="card-header">
               <asp:Label ID="lblEditMode" runat="server"></asp:Label> Role
            </div>
            <div class="card-block">
                <div class="row m-a-0">
                  <div class="col-lg-12 form-horizontal">
                      <h4 class="card-title">Role Info</h4>
                      <div class="form-group">
                        <label class="col-sm-2 control-label">Role Name</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtRoleName" runat="server"  CssClass="form-control" placeholder="Insert role name"></asp:TextBox>
                        </div>                                       
                      </div>     
                  
                      <h4 class="card-title">Authorization</h4>
                        
                        <div class="col-sm-12">
                                <div class="card" style="border: 0.125rem solid #e4e4e4;">
                                  <div class="card-block p-a-0">
                                    <div class="box-tab m-b-0">
                                      <ul class="nav nav-tabs">                                    
                                        <li class="" id="liTabAdminWeb" runat="server">
                                            <asp:LinkButton ID="btnTabAdminWeb" runat="server">
                                                <div class="iti-flag gb" style="float:left; margin-top:3px; margin-right:3px; cursor:pointer;"></div> <span>Admin Web</span>
                                                <span class="badge pull-right text-white bg-blue"><asp:Label ID="lblBadgeAdmin" runat="server"></asp:Label></span>
                                            </asp:LinkButton>
                                        </li>
                                        <li class="" id="liTabStaffConsole" runat="server">
                                            <asp:LinkButton ID="btnTabStaffConsole" runat="server">
                                                <div class="iti-flag ru" style="float:left; margin-top:0px; margin-right:3px; cursor:pointer;"></div> <span>Kiosk' Staff Console</span>
                                                <span class="badge pull-right text-white bg-blue"><asp:Label ID="lblBadgeStaffConsole" runat="server"></asp:Label></span>
                                            </asp:LinkButton>
                                        </li>                                    
                                        <li class="" id="liTabMembers" runat="server">
                                            <asp:LinkButton ID="btnTabMembers" runat="server">
                                                <div class="iti-flag cn" style="float:left; margin-top:3px; margin-right:3px; cursor:pointer;"></div> <span>Members List</span>
                                                <span class="badge pull-right text-white bg-blue"><asp:Label ID="lblBadgeMember" runat="server"></asp:Label></span>
                                            </asp:LinkButton>
                                        </li>                            
                                      </ul>
                                      <div style="padding: 0.9375rem;">

                                        <asp:Panel id="tabAdminWeb" runat="server">                              
                                        <asp:Repeater ID="rptAdminWeb" runat="server">
                                            <ItemTemplate>
                                                <h5><asp:Label ID="lblHeader" runat="server"></asp:Label></h5>
                                                    <asp:Repeater ID="rpt" runat="server">
                                                        <ItemTemplate>
                                                            <div class="form-group">
                                                                <label class="col-sm-4 control-label" ><asp:Label ID="lblFN" runat="server"></asp:Label></label>
                                                                <div class="col-sm-8">
                                                                    <uc2:ucAuthorizeSelector2 ID="Selector2" SelectedRole="0" runat="server" IsVisible="false" />
                                                                    <uc3:ucAuthorizeSelector3 ID="Selector3" SelectedRole="0" runat="server" IsVisible="false" />
                                                                </div>                                        
                                                              </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                            </ItemTemplate>
                                        </asp:Repeater>         
                                        </asp:Panel>

                                        <asp:Panel id="tabStaffConsole" runat="server">
                                         <asp:Repeater ID="rptStaffConsole" runat="server">
                                            <ItemTemplate>
                                                <h5><asp:Label ID="lblHeader" runat="server"></asp:Label></h5>
                                                    <asp:Repeater ID="rpt" runat="server">
                                                        <ItemTemplate>
                                                            <div class="form-group">
                                                                <label class="col-sm-4 control-label" ><asp:Label ID="lblFN" runat="server"></asp:Label></label>
                                                                <div class="col-sm-8">
                                                                    <uc2:ucAuthorizeSelector2 ID="Selector2" SelectedRole="0" runat="server" IsVisible="false" />
                                                                    <uc3:ucAuthorizeSelector3 ID="Selector3" SelectedRole="0" runat="server" IsVisible="false" />
                                                                </div>                                        
                                                              </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                            </ItemTemplate>
                                        </asp:Repeater>   
                                        </asp:Panel>

                                        <asp:Panel id="tabMembers" runat="server">                              
                                                                    
                                          <h5>Total <asp:Label ID="lblTotalUser" runat="server"></asp:Label> members</h5>
                                          <div class="card bg-white">
                                              <div class="card-block">
                                                <div class="row demo-button3">
                                                  <asp:Repeater ID="rptUser" runat="server">
                                                      <ItemTemplate>
                                                        <span class="card-block bg-blue-lighter text-white h5 user-item">
                                                            <i class="fa fa-user"></i>  
                                                            <asp:Label ID="lblUser" runat="server"></asp:Label> 
                                                            <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete">x</asp:LinkButton>
                                                        </span>
                                                      </ItemTemplate>
                                                      <FooterTemplate>
                                                          
                                                      </FooterTemplate>
                                                  </asp:Repeater>                             
                                                </div>
                                              </div>
                                            </div>
                                            <div class="row m-t">
                                                <asp:LinkButton CssClass="btn btn-primary btn-icon loading-demo mr5 btn-shadow" ID="lnkAddMember" runat="server">
                                                    <i class="fa fa-plus-circle"></i>
                                                    <span>Add new member</span>
                                                </asp:LinkButton>
                                                <asp:LinkButton CssClass="btn btn-danger btn-icon loading-demo mr5 btn-shadow" ID="lnkClearMember" runat="server">
                                                    <i class="fa fa-times-circle"></i>
                                                    <span>Clear all member</span>
                                                </asp:LinkButton>
                                                <ajaxToolkit:ConfirmButtonExtender ID="cfmClear" runat="server" TargetControlID="lnkClearMember" ConfirmText="Are you sure to clear all member in the list?" />
                                            </div>
                                        </asp:Panel>                                                        
                                      </div>
                                    </div>
                                  </div>
                                </div>
                              </div>
                  
                               
                      <div class="form-group" style="margin-left:-5px;">
                            <h4 class="card-title col-sm-2 control-label" style="text-align:left;">Active Status </h4>  
                            <label class="col-sm-10 cb-checkbox cb-md">
                                <asp:CheckBox ID="chkActive" runat="server"/>
                            </label>
                      </div>
                      <div class="form-group" style="text-align:right">
                            <asp:LinkButton CssClass="btn btn-success btn-icon loading-demo mr5 btn-shadow" ID="btnSave" runat="server">
                              <i class="fa fa-save"></i> <span>Save</span>
                            </asp:LinkButton>
                            <asp:LinkButton CssClass="btn btn-warning btn-icon loading-demo mr5 btn-shadow" ID="btnBack" runat="server">
                              <i class="fa fa-rotate-left"></i> <span>Cancel</span>
                            </asp:LinkButton>
                      </div>
                  </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="pnlSelectUser" runat="server" Visible="false">
         <div class="sweet-overlay" tabindex="-1" style="opacity: 1.03; display: block;"></div>
         <div class="sweet-alert show-input showSweetAlert visible"  style="display: block; width:500px;height:600px; ">
                  
                    <table class="table table-bordered datatable responsive align-middle bordered">
                      <thead>
                        <tr>
                          <th>Select User</th>                            
                        </tr>
                      </thead>
                      <tbody>
                          <asp:Repeater ID="rptUnselectedUser" runat="server">
                              <ItemTemplate>
                                  <tr>
                                      <td id="td" runat="server" style="cursor:pointer;" class=""><asp:Label ID="lbl" runat="server"></asp:Label>
                                          <asp:CheckBox ID="chk" runat="server" Style="display:none;" />
                                          <asp:Button ID="btn" runat="server" Style="display:none;" CommandName="Selected" />
                                      </td>
                                   </tr>   
                              </ItemTemplate>
                          </asp:Repeater> 
                      </tbody>
                    </table>
                  <asp:TextBox ID="txtBufferSearch" runat="server" style="display:none;" ClientIDMode="Static"></asp:TextBox>
              <div class="form-group btn-group btn-group-justified">
                   <div class="col-sm-6">
                      <asp:Button ID="btnSelectUser" runat="server" Text="Confirm" CssClass="btn btn-success" />
                   </div>           
                   <div class="col-sm-6">
                       <asp:Button ID="btnCancelUser" runat="server" Text="Cancel" CssClass="btn btn-warning" /> 
                   </div>
                       
              </div>
          </div>
       </asp:Panel> 
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

<asp:Content ID="ScriptContainer" ContentPlaceHolderID="ScriptContainer" runat="server">

  <!-- page scripts -->
  <script src="vendor/chosen_v1.4.0/chosen.jquery.min.js" type="text/javascript" language="javascript"></script>
  <script src="vendor/jquery.tagsinput/src/jquery.tagsinput.js" type="text/javascript" language="javascript"></script>
  <script src="vendor/checkbo/src/0.1.4/js/checkBo.min.js" type="text/javascript" language="javascript"></script>
  <script src="vendor/intl-tel-input//build/js/intlTelInput.min.js" type="text/javascript" language="javascript"></script>
  <script src="vendor/moment/min/moment.min.js" type="text/javascript" language="javascript"></script>
  <script src="vendor/bootstrap-daterangepicker/daterangepicker.js" type="text/javascript" language="javascript"></script>
  <script src="vendor/bootstrap-datepicker/js/bootstrap-datepicker.js" type="text/javascript" language="javascript"></script>
  <script src="vendor/bootstrap-timepicker/js/bootstrap-timepicker.min.js" type="text/javascript" language="javascript"></script>
  <script src="vendor/clockpicker/dist/jquery-clockpicker.min.js" type="text/javascript" language="javascript"></script>
  <script src="vendor/mjolnic-bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js" type="text/javascript" language="javascript"></script>
  <script src="vendor/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.min.js" type="text/javascript" language="javascript"></script>
  <script src="vendor/select2/dist/js/select2.js" type="text/javascript" language="javascript"></script>
  <script src="vendor/selectize/dist/js/standalone/selectize.min.js" type="text/javascript" language="javascript"></script>
  <script src="vendor/jquery-labelauty/source/jquery-labelauty.js" type="text/javascript" language="javascript"></script>
  <script src="vendor/bootstrap-maxlength/bootstrap-maxlength.min.js" type="text/javascript" language="javascript"></script>
  <script src="vendor/typeahead.js/dist/typeahead.bundle.js" type="text/javascript" language="javascript"></script>
  <script src="vendor/multiselect/js/jquery.multi-select.js" type="text/javascript" language="javascript"></script>
  <!-- end page scripts -->
  <!-- page scripts -->
  <script src="Scripts/jquery.dataTables.min.js"></script>   
  <!-- end page scripts -->
  <!-- initialize page scripts -->
  <script src="scripts/Setting_Role.js" type="text/javascript"  lang="javascript"></script>
  <script src="scripts/forms/plugins.js" type="text/javascript"  lang="javascript"></script>  
  <!-- end initialize page scripts -->
</asp:Content>
