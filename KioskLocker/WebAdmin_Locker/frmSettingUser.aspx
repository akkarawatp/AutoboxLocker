<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Master/MasterPage.Master" CodeFile="frmSettingUser.aspx.vb" Inherits="frmSettingUser" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="HeaderContainer" ContentPlaceHolderID="HeaderContainer" runat="server">
      <!-- page stylesheets -->
      <link rel="stylesheet" type="text/css" href="vendor/checkbo/src/0.1.4/css/checkBo.min.css" />
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
      </style>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-title">
        <div class="title">Master Data > User Authorization > User</div>
       <%-- <div class="sub-title">Manage and assign roles for each user</div>--%>
    </div>
<asp:UpdatePanel ID="udpList" runat="server">
    <ContentTemplate>
    <asp:Panel ID="pnlList" runat="server" CssClass="card bg-white" Visible="True">
        <div class="card-header">
            Found : <asp:Label ID="lblTotalList" runat="server"></asp:Label> User(s)
        </div>
        <div class="card-block">
            <div class="no-more-tables">
            <table class="table table-bordered m-b-0">
              <thead>
                <tr>
                  <th>User Name</th>
                  <th>Roles</th>
                  <th>Locations</th>
                  <th id="ColEdit" runat="server">Edit</th>
                  <th id="ColDelete" runat="server">Delete</th>
                </tr>                
              </thead>
              <tbody>
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <tr>                 
                  <td data-title="User Name" class="text-primary" id="td" runat="server"><i class="icon-user"></i> <asp:Label ID="lblUserName" runat="server"></asp:Label></td>
                  <td data-title="Roles" class="numeric"><asp:Label ID="lblROles" runat="server"></asp:Label></td>
                  <td data-title="Locations" class="numeric"><asp:Label ID="lblLocation" runat="server"></asp:Label></td>                  
                  <td data-title="Edit" class="numeric" id="ColEdit" runat="server"><asp:Button CssClass="btn btn-success" ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" /></td>
                  <td data-title="Delete" class="numeric" id="ColDelete" runat="server"><asp:Button CssClass="btn btn-danger" ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" /></td>
                  <ajaxToolkit:ConfirmButtonExtender ID="cfmDelete" runat="server" TargetControlID="btnDelete" />
                </tr> 
            </ItemTemplate>
        </asp:Repeater>               
              </tbody>
            </table>
            </div>
            
            <div class="row m-t">
                <asp:LinkButton CssClass="btn btn-primary btn-icon loading-demo mr5 btn-shadow" ID="btnAdd" runat="server">
                  <i class="fa fa-plus-circle"></i>
                  <span>Add new user</span>
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
            <asp:Label ID="lblEditMode" runat="server"></asp:Label> User
        </div>
        <div class="card-block">
            <div class="row m-a-0">
              <div class="col-lg-12 form-horizontal">
                  <h4 class="card-title">User Info</h4>
                   <div class="form-group">
                    <label class="col-sm-2 control-label">Account No</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtAccountNo"  Enabled="false" runat="server"  CssClass="form-control"  placeholder=""></asp:TextBox>
                    </div>                                        
                  </div>
                   <div class="form-group">
                    <label class="col-sm-2 control-label">First Name</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtFirstName" runat="server"  CssClass="form-control"  placeholder="Insert first name" MaxLength="50"></asp:TextBox>
                    </div>  
                    <label class="col-sm-2 control-label">Last Name</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtLastName" runat="server"  CssClass="form-control"  placeholder="Insert last name" MaxLength="50"></asp:TextBox>
                    </div>                                       
                  </div>
                  <div class="form-group">
                    <label class="col-sm-2 control-label">Company Name</label>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtCompanyName" runat="server"  CssClass="form-control"  placeholder="Insert company name" MaxLength="200"></asp:TextBox>
                    </div>                                       
                  </div>
                  <div class="form-group">
                    <label class="col-sm-2 control-label">Email</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Insert valid email for any notification" MaxLength="100"></asp:TextBox>
                    </div>     
                     <label class="col-sm-2 control-label">Mobile No</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtMobileNo" runat="server"  CssClass="form-control"  placeholder="Insert mobile no" MaxLength="10"></asp:TextBox>
                    </div>                                   
                  </div>


                 <h4 class="card-title">Login Info</h4>
                  <div class="form-group">
                    <label class="col-sm-2 control-label">User Name</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtUsername" runat="server"  CssClass="form-control"  placeholder="Insert user name"></asp:TextBox>
                    </div>                                        
                  </div>
                   <div class="form-group">
                    <label class="col-sm-2 control-label">Password</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtPassword" runat="server" textmode="Password" CssClass="form-control"  placeholder="Insert password" MaxLength="20"></asp:TextBox>
                    </div>                                        
                  </div>
                   <div class="form-group">
                    <label class="col-sm-2 control-label">Confirm Password</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" textmode="Password"  CssClass="form-control"  placeholder="Insert confirm password" MaxLength="20"></asp:TextBox>
                    </div>                                        
                  </div>
                  
                  <h4 class="card-title">Authorization</h4>
                    <label class="col-sm-2 control-label"></label>
                    <div class="col-sm-10">
                            <div class="card" style="border: 0.125rem solid #e4e4e4;">
                              <div class="card-block p-a-0">
                                <div class="box-tab m-b-0">
                                  <ul class="nav nav-tabs">
                                    <li class="" id="liTabRole" runat="server">
                                        <asp:LinkButton ID="btnTabRole" runat="server">
                                            <div class="iti-flag gb" style="float:left; margin-top:3px; margin-right:3px; cursor:pointer;"></div> <span>Roles</span>
                                            <span class="badge pull-right text-white bg-green"><asp:Label ID="lblBadgeRole" runat="server"></asp:Label></span>
                                        </asp:LinkButton>
                                    </li>
                                    <li class="" id="liTabLocation" runat="server">
                                        <asp:LinkButton ID="btnTabLocation" runat="server">
                                            <div class="iti-flag ru" style="float:left; margin-top:0px; margin-right:3px; cursor:pointer;"></div> <span>Locations</span>
                                            <span class="badge pull-right text-white bg-green"><asp:Label ID="lblBadgeLocation" runat="server"></asp:Label></span>
                                        </asp:LinkButton>
                                    </li>                                                             
                                  </ul>
                                  <div style="padding: 0.9375rem;">

                                    <asp:Panel id="tabRole" runat="server">
                                        <asp:Repeater ID="rptRole" runat="server">
                                            <ItemTemplate>                                              
                                               <div class="form-group" style="margin-left:-5px;">                                            
                                                   <label class="cb-checkbox cb-md" style="width:50px; float:left;">
                                                        <asp:CheckBox ID="chk" runat="server"/>
                                                    </label> 
                                                   <h5 class="card-title col-sm-10 control-label" style="text-align:left;">
                                                    <i class="icon icon-users"></i> <asp:Label ID="lbl" runat="server"></asp:Label></h5>                                                     
                                              </div>                                                
                                            </ItemTemplate>
                                       </asp:Repeater> 
                                    </asp:Panel>

                                    <asp:Panel id="tabLocation" runat="server"> 
                                        <asp:Repeater ID="rptLocation" runat="server">
                                            <ItemTemplate>
                                                <div class="form-group" style="margin-left:-5px;">                                            
                                                    <label class="cb-checkbox cb-md" style="width:50px; float:left;">
                                                        <asp:CheckBox ID="chk" runat="server"/>
                                                    </label>  
                                                    <h5 class="card-title col-sm-10 control-label" style="text-align:left;">
                                                    <i class="icon icon-pointer"></i> <asp:Label ID="lbl" runat="server"></asp:Label></h5>                                                    
                                                </div>                                                
                                            </ItemTemplate>
                                        </asp:Repeater>        
                                    </asp:Panel>  
                                      
                                    <asp:Button ID="btnUpdateBadge" runat="server" Text="UpdateBadge" Style="display:none;" />                                                                                          
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
                          <i class="fa fa-save"></i>
                          <span>Save</span>
                        </asp:LinkButton>
                        <asp:LinkButton CssClass="btn btn-warning btn-icon loading-demo mr5 btn-shadow" ID="btnBack" runat="server">
                          <i class="fa fa-rotate-left"></i>
                          <span>Cancel</span>
                        </asp:LinkButton>
                  </div>
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
  <!-- initialize page scripts -->
  <script type="text/javascript" language="javascript" src="scripts/forms/plugins.js" type="text/javascript"></script>
  <script type="text/javascript" language="javascript" src="vendor/jquery.maskedinput/dist/jquery.maskedinput.min.js"></script>
  <script type="text/javascript" language="javascript">

      function initForm() {
          $('.txt-mobile').mask('(999) 999-9999');          
      }initForm();
      
  </script>
  <!-- end page scripts -->

  <!-- end initialize page scripts -->
</asp:Content>
