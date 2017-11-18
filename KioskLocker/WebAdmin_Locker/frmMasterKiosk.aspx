<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Master/MasterPage.Master" CodeFile="frmMasterKiosk.aspx.vb" Inherits="frmMasterKiosk" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<%@ Register src="uc_Printer_Stock_UI.ascx" tagname="uc_Printer_Stock_UI" tagprefix="uc" %>
<%@ Register src="uc_Peripheral_UI.ascx" tagname="uc_Peripheral_UI" tagprefix="uc" %>
<%@ Register src="uc_MoneyStock_UI.ascx" tagname="uc_MoneyStock_UI" tagprefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContainer" runat="server">

  <!-- page stylesheets -->
  <link rel="stylesheet" href="vendor/chosen_v1.4.0/chosen.min.css">
  <link rel="stylesheet" href="vendor/checkbo/src/0.1.4/css/checkBo.min.css" />
  <link rel="stylesheet" href="vendor/intl-tel-input/build/css/intlTelInput.css">
  <link rel="stylesheet" href="vendor/jquery-labelauty/source/jquery-labelauty.css" />
  
  <!-- end page stylesheets -->

    <style type="text/css">
        .demo-button .btn {
            min-width:inherit;
            margin-bottom: 5px;
            margin-right: 5px;
        }

        .fHidden {
            display:none;
        }
        
        span.btn
        {
            cursor:default;
            }
            
        .bg-stretch
        {
            -webkit-background-size: cover; /* For WebKit*/
            -moz-background-size: cover;    /* Mozilla*/
            -o-background-size: cover;      /* Opera*/
            background-size: cover;         /* Generic*/
            background-position:center;
            background-repeat:no-repeat;
            }
            
        .square-div
        {
            padding-bottom:100%;
            }
         
         @media (max-width: 47em) 
         {
          .demo-button {text-align:center;}
          .demo-button .btn-success {width:45%;}
          .demo-button .btn-danger {width:45%;}
          .demo-button .btn-default {width:45%;}
          .mobile_group_head{ padding-top:10px; padding-bottom:10px; text-align:center;}
         }
         
         @media (min-width: 48em) 
         {
             .mobile_product div span
             {text-align:center; overflow:hidden;}
         }
         
          .numeric
          {
            text-align:center;
          }

        .ads {
            cursor:pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-title">
        <div class="title">Master Data > Kiosk</div>
        <div class="sub-title"></div>
    </div>
<asp:UpdatePanel ID="udpList" runat="server">
   <ContentTemplate>
        <asp:Panel ID="pnlList" runat="server" CssClass="card " Visible="True">
            <div class="card-header">
                Found : <asp:Label ID="lblTotalList" runat="server"></asp:Label> Machine(s)
            </div>
            <div class="card-block">
                
                <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        
                        <div class="col-sm-12">
                             <div class="card card-block no-border bg-white row-equal align-middle">
                                 <div class="col-sm-3">
                                     <div class="col-sm-12">
                                         <h3 class="m-a-0 text-green" id="h3" runat="server">
                                             <asp:Label ID="lblComName" runat="server"></asp:Label>

                                         </h3>
                                     </div>
                                     <div class="col-sm-12">
                                        <div class="column">
                                            <asp:Image ID="imgKioskIcon" runat="server" ImageUrl="images/icon/100/koisk_ok.png" Height="60px" />
                                        </div>
                                        <div class="column">       
                                            <h5><asp:Label ID="lblLocation" runat="server"></asp:Label></h5>                                     
                                            <h5><asp:Label ID="lblIP" runat="server"></asp:Label></h5>
                                            <h6><asp:Label ID="lblMacAddress" runat="server"></asp:Label></h6>
                                        </div>
                                    </div>

                                    <div class="col-sm-12 mobile_product">
                                                                             
                                        <uc:uc_Printer_Stock_UI ID="Printer" runat="server" />
                                        <asp:Panel ID="pnlBlankPrinter" runat="server" Style="margin-top:20px;" Visible="false"></asp:Panel>                          
                                        
                                    </div>
                                     

                                  </div>
                                  <div class="col-sm-9">                                       
                                      <uc:uc_Peripheral_UI ID="Peripheral" runat="server" />
                                        <div class="row">
                                         <uc:uc_MoneyStock_UI ID="MoneyStock" runat="server" />
                                        </div>
                                  </div>
                                  <div class="col-sm-9">
                                     
                                  </div>     
                                 <div class="col-sm-9">
                                     <asp:LinkButton CssClass="btn btn-primary btn-icon loading-demo mr5 btn-shadow col-sm-4" ID="btnMonitor" runat="server" CommandName="Edit">
                                         <i class="icon-target"></i>
                                          <span>Realtime Monitoring</span>
                                     </asp:LinkButton>
                                     <asp:LinkButton CssClass="btn btn-success btn-icon loading-demo mr5 btn-shadow col-sm-4" ID="btnEdit" runat="server" CommandName="Edit">
                                         <i class="fa fa-cog"></i>
                                          <span>Change configuration</span>
                                     </asp:LinkButton>
                                 </div>       
                             </div> 
                        </div>
                        
                   </ItemTemplate>
                </asp:Repeater>
                <asp:Button ID="btnUpdateStatus" runat="server" style="display:none;" ClientIDMode="Static" />
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="udpEdit" runat="server">
    <ContentTemplate>
         <asp:Panel ID="pnlEdit" runat="server" Visible="false"  CssClass="card bg-white">
              <div class="card-header">
                <asp:Label ID="lblEditMode" runat="server"></asp:Label> Kiosk
              </div>
              <div class="card-block">
                <div class="row m-a-0">
                  <div class="col-lg-12 form-horizontal">
                  <div class="row m-b">
                      <h4 class="card-title">Kiosk Info  : &nbsp; &nbsp; <span class="h3 m-a-0 text-green m-l" id="lblKioskCode" runat="server"></span></h4> 
                      <div class="form-group">
                        <label class="col-sm-2 control-label">Location</label>
                        <div class="col-sm-4">
                              <asp:DropDownList ID="ddlLocation" runat="server" data-placeholder="Select location" AutoPostBack="true" CssClass="chosen form-control" Width="100%">
                              </asp:DropDownList>
                        </div>                 
                      </div>
                      <h4 class="card-title m-t">Network Information</h4>

                      <div class="form-group">
                        <label class="col-sm-2 control-label">Computer Name</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtComName" runat="server" CssClass="form-control" style="text-align:center; " MaxLength="50"/>
                        </div>
                        <label class="col-sm-2 control-label">&nbsp;&nbsp;&nbsp;</label>
                        <div class="col-sm-4">
                            <input class="form-control" style="visibility:hidden;" />
                        </div>
                      </div>

                      <div class="form-group">
                        <label class="col-sm-2 control-label">IP Address</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtIP1" runat="server" Width="50px" MaxLength="3" CssClass="form-control" style="text-align:center; display:inline; padding:0; " /> .
                            <asp:TextBox ID="txtIP2" runat="server" Width="50px" MaxLength="3" CssClass="form-control" style="text-align:center; display:inline; padding:0; " /> .
                            <asp:TextBox ID="txtIP3" runat="server" Width="50px" MaxLength="3" CssClass="form-control" style="text-align:center; display:inline; padding:0; " /> .
                            <asp:TextBox ID="txtIP4" runat="server" Width="50px" MaxLength="3" CssClass="form-control" style="text-align:center; display:inline; padding:0; " />
                         </div>                        
                        <label class="col-sm-2 control-label m-t">Mac Address</label>
                        <div class="col-sm-4 m-t">
                          <%--<asp:TextBox ID="txtMacAddress" runat="server" CssClass="form-control" Width="65%" style="display:inline;" MaxLength="50"></asp:TextBox>--%>
                            <asp:TextBox ID="txtMAC1" runat="server" Width="50px" MaxLength="2" CssClass="form-control" style="text-align:center; display:inline; padding:0; " /> -
                            <asp:TextBox ID="txtMAC2" runat="server" Width="50px" MaxLength="2" CssClass="form-control" style="text-align:center; display:inline; padding:0; " /> -
                            <asp:TextBox ID="txtMAC3" runat="server" Width="50px" MaxLength="2" CssClass="form-control" style="text-align:center; display:inline; padding:0; " /> -
                            <asp:TextBox ID="txtMAC4" runat="server" Width="50px" MaxLength="2" CssClass="form-control" style="text-align:center; display:inline; padding:0; " /> -
                            <asp:TextBox ID="txtMAC5" runat="server" Width="50px" MaxLength="2" CssClass="form-control" style="text-align:center; display:inline; padding:0; " /> -
                            <asp:TextBox ID="txtMAC6" runat="server" Width="50px" MaxLength="2" CssClass="form-control" style="text-align:center; display:inline; padding:0; " />
                            <asp:Button ID="btnGetMac" runat="server" CssClass="btn btn-facebook" Width="30%" Text="Get By IP" Visible="false" /> 
                        </div>
                      </div>                     
                  </div>         
                   <div class="row m-b">
                      <h4 class="card-title">Material Stock Control Level</h4>
                        <asp:Repeater ID="rpt_Stock" runat="server">
                            <ItemTemplate>
                                  <div class="card col-sm-3" style="padding:0; padding-right:0;">
                                    <div class="card-header" style="text-align:center;">
                                        <asp:Image ImageUrl="Images/BlackDot.png" Height="30px" ID="imgIcon" runat="server" /> 
                                        <asp:Label ID="lblDeviceName" runat="server"></asp:Label>
                                    </div>
                                    <div class="card-block no-border bg-white row-equal align-middle">
                                      <div class="form-group m-b">
                                        <label class="col-sm-6 control-label text-primary">Stock Capaity</label>
                                        <div class="col-sm-6">        
                                             <asp:TextBox ID="txtMax" runat="server" CssClass="form-control" ></asp:TextBox>
                                        </div>
                                      </div>
                                      <asp:Panel ID="pnlMoveDown" runat="server" Visible="false">
                                          <div class="form-group m-b">
                                            <label class="col-sm-6 control-label text-warning">Warning at</label>
                                            <div class="col-sm-6">         
                                                 <asp:TextBox ID="txtWarningDown" runat="server" CssClass="form-control" ></asp:TextBox>
                                            </div>
                                          </div>
                                          <div class="form-group ">
                                            <label class="col-sm-6 control-label text-danger">Alert at</label>
                                            <div class="col-sm-6">             
                                                 <asp:TextBox ID="txtCriticalDown" runat="server" CssClass="form-control" ></asp:TextBox>
                                            </div>
                                          </div>
                                      </asp:Panel>
                                      <asp:Panel ID="pnlMoveUp" runat="server" Visible="false">
                                          <div class="form-group ">
                                            <label class="col-sm-6 control-label text-danger">Alert at</label>
                                            <div class="col-sm-6">             
                                                 <asp:TextBox ID="txtCriticalUp" runat="server" CssClass="form-control" ></asp:TextBox>
                                            </div>
                                          </div>
                                          <div class="form-group m-b">
                                            <label class="col-sm-6 control-label text-warning">Warning at</label>
                                            <div class="col-sm-6">         
                                                 <asp:TextBox ID="txtWarningUp" runat="server" CssClass="form-control" ></asp:TextBox>
                                            </div>
                                          </div>                                          
                                      </asp:Panel>              
                                    </div>
                                  </div>
                            </ItemTemplate>
                        </asp:Repeater>                    
                   </div>

                      <div class="form-group m-t" style="text-align:left;" >
                            <h4 class="card-title col-sm-2 control-label" style="text-align:left;" >Active Status </h4>  
                             
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
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContainer" runat="server">

  <!-- page scripts -->
  <script src="vendor/chosen_v1.4.0/chosen.jquery.min.js" type="text/javascript" lang="javascript"></script>
  <script src="vendor/jquery.tagsinput/src/jquery.tagsinput.js" type="text/javascript" lang="javascript"></script>
  <script src="vendor/checkbo/src/0.1.4/js/checkBo.min.js" type="text/javascript" lang="javascript"></script>
  <script src="vendor/intl-tel-input//build/js/intlTelInput.min.js" type="text/javascript" lang="javascript"></script>
  <script src="vendor/moment/min/moment.min.js" type="text/javascript" lang="javascript"></script>
  <script src="vendor/bootstrap-daterangepicker/daterangepicker.js" type="text/javascript" lang="javascript"></script>
  <script src="vendor/bootstrap-datepicker/js/bootstrap-datepicker.js" type="text/javascript" lang="javascript"></script>
  <script src="vendor/bootstrap-timepicker/js/bootstrap-timepicker.min.js" type="text/javascript" lang="javascript"></script>
  <script src="vendor/clockpicker/dist/jquery-clockpicker.min.js" type="text/javascript" lang="javascript"></script>
  <script src="vendor/mjolnic-bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js" type="text/javascript" lang="javascript"></script>
  <script src="vendor/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.min.js" type="text/javascript" lang="javascript"></script>
  <script src="vendor/select2/dist/js/select2.js" type="text/javascript" lang="javascript"></script>
  <script src="vendor/selectize/dist/js/standalone/selectize.min.js" type="text/javascript" lang="javascript"></script>
  <script src="vendor/jquery-labelauty/source/jquery-labelauty.js" type="text/javascript" lang="javascript"></script>
  <script src="vendor/bootstrap-maxlength/bootstrap-maxlength.min.js" type="text/javascript" lang="javascript"></script>
  <script src="vendor/typeahead.js/dist/typeahead.bundle.js" type="text/javascript" lang="javascript"></script>
  <script src="vendor/multiselect/js/jquery.multi-select.js" type="text/javascript" lang="javascript"></script>

  <!-- end page scripts -->
  <!-- initialize page scripts -->
  <script src="scripts/forms/plugins.js" type="text/javascript" lang="javascript"></script>
<%--  <script src="scripts/ui/alert.js"></script>--%>
  <script type="text/javascript" lang="javascript">


      (function ($) {
          resizeAds();
          restorePassword();
      })(jQuery);


      function resizeAds() {
          var w = $(".ads_container").width() - 20;
          $(".ads").width(w);
          $(".ads").height(w*320/1080);
      } resizeAds();

      function restorePassword()
      {
          $('#txtDBPassword').val($('#bufDBPassword').val());
          $('#txtCAMPassword').val($('#bufCAMPassword').val());         
      } restorePassword();
      
      var timerRefresh;
      var refreshInterval = 15000;
      function setRefreshMonitoring()
      {          
          timerRefresh = setTimeout(updateMonitoring, refreshInterval);
      }
      $(document).ready(function () {
          setRefreshMonitoring();
      });
      

      function updateMonitoring()
      {
          
          var btn = document.getElementById('btnUpdateStatus');
          if (btn)
          {
              btn.click();
              timerRefresh = setTimeout(updateMonitoring, refreshInterval);
          }
      }
  </script>
  <!-- end initialize page scripts -->

</asp:Content>
