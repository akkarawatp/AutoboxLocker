<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master/MasterPage.Master" CodeFile="frmAlarmMonitoring.aspx.vb" Inherits="frmAlarmMonitoring" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContainer" runat="server">
    <!-- page stylesheets -->
  <link rel="stylesheet" href="vendor/chosen_v1.4.0/chosen.min.css">
  <link rel="stylesheet" href="vendor/checkbo/src/0.1.4/css/checkBo.min.css" />
  <style type="text/css">
         
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
      
         .condition {
        border:1px solid white;
      
      }
         
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-title">
        <div class="title">Alarm & Monitoring > Kiosk Monitoring</div>
        <%--<div class="sub-title">Real-Time remote monitoring kiosk' hardware condition, stock control level and software working properly.</div>--%>
    </div>

<asp:UpdatePanel ID="udpList" runat="server">
   <ContentTemplate>
        <div class="card">
            <div class="card-header">
                Found : <asp:Label ID="lblTotalList" runat="server"></asp:Label> Machine(s)
            </div>
        </div>
       <div class="row">
           <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        
                        <div class="col-sm-6">
                             <div class="card card-block no-border bg-white row-equal align-middle">
                                 <div class="col-sm-6">
                                    <a id="aInfo" runat="server">
                                        <div class="row">
                                            <div class="column">
                                                <asp:Image ID="imgKioskIcon" runat="server" ImageUrl="images/icon/100/koisk_ok.png" Height="60px" />
                                            </div>
                                            <div class="column">
                                                <h3 class="m-a-0 text-green" id="h3" runat="server"><asp:Label ID="lblKioskCode" runat="server"></asp:Label></h3>
                                            </div>                                            
                                        </div>
                                        <div class="row">    
                                            <h5><asp:Label ID="lblLocation" runat="server"></asp:Label></h5>
                                            <h5>IP : <asp:Label ID="lblIP" runat="server"></asp:Label></h5>
                                            <h5>Mac : <asp:Label ID="lblMac" runat="server"></asp:Label></h5>                                            
                                        </div>
                                    </a>
                                  </div>
                                 <div class="col-sm-6">                                      
                                     <div class="col-sm-12 mobile_product">                                        
                                        <div class="btn-group-justified">
                                            <asp:LinkButton class="btn btn-success btn-icon condition" id="lnkHardware" runat="server">
                                                <i class="fa fa-dashboard"></i>
                                              <span>Hardware Condition</span>
                                            </asp:LinkButton>                                                               
                                        </div>
                                    </div>  
                                     <div class="col-sm-12 mobile_product">                                        
                                        <div class="btn-group-justified">
                                             <asp:LinkButton class="btn btn-success btn-icon condition" id="lnkPeripheral" runat="server">
                                                <i class="fa fa-gears"></i>
                                              <span>Peripheral Condition</span>
                                            </asp:LinkButton>  
                                        </div>
                                    </div> 
                                   <div class="col-sm-12 mobile_product">                                        
                                        <div class="btn-group-justified">
                                            <asp:LinkButton class="btn btn-success btn-icon condition" id="lnkStock" runat="server">
                                                <i class="fa fa-line-chart left"></i>
                                              <span>Stock Level</span>
                                            </asp:LinkButton>                                                                
                                        </div>
                                    </div>
                                    
                                      <div class="col-sm-12 mobile_product">                                        
                                        <div class="btn-group-justified"> 
                                             <asp:LinkButton class="btn btn-success btn-icon condition" id="lnkNetwork" runat="server">
                                                <i class="fa fa-plug"></i>
                                              <span>Network Connection</span>
                                            </asp:LinkButton> 
                                         </div>
                                    </div>                                                                    
                                 </div>     
                             </div> 
                        </div>                        
                   </ItemTemplate>
                </asp:Repeater>
            <asp:Button ID="btnUpdateStatus" runat="server" style="display:none;" ClientIDMode="Static" />       
       </div>
    </ContentTemplate>
</asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContainer" runat="server">

  <!-- page scripts -->
  <script src="vendor/chosen_v1.4.0/chosen.jquery.min.js" type="text/javascript" ></script>
  <script src="vendor/jquery.tagsinput/src/jquery.tagsinput.js" type="text/javascript" ></script>
  <script src="vendor/checkbo/src/0.1.4/js/checkBo.min.js" type="text/javascript" ></script>
  <script src="vendor/intl-tel-input//build/js/intlTelInput.min.js" type="text/javascript" ></script>
  <script src="vendor/moment/min/moment.min.js" type="text/javascript" ></script>
  <script src="vendor/bootstrap-daterangepicker/daterangepicker.js" type="text/javascript" ></script>
  <script src="vendor/bootstrap-datepicker/js/bootstrap-datepicker.js" type="text/javascript" ></script>
  <script src="vendor/bootstrap-timepicker/js/bootstrap-timepicker.min.js" type="text/javascript" ></script>
  <script src="vendor/clockpicker/dist/jquery-clockpicker.min.js" type="text/javascript" ></script>
  <script src="vendor/mjolnic-bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js" type="text/javascript" ></script>
  <script src="vendor/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.min.js" type="text/javascript" ></script>
  <script src="vendor/select2/dist/js/select2.js" type="text/javascript" ></script>
  <script src="vendor/selectize/dist/js/standalone/selectize.min.js" type="text/javascript" ></script>
  <script src="vendor/jquery-labelauty/source/jquery-labelauty.js" type="text/javascript" ></script>
  <script src="vendor/bootstrap-maxlength/bootstrap-maxlength.min.js" type="text/javascript" ></script>
  <script src="vendor/typeahead.js/dist/typeahead.bundle.js" type="text/javascript" ></script>
  <script src="vendor/multiselect/js/jquery.multi-select.js" type="text/javascript" ></script>
  <!-- end page scripts -->
  <!-- initialize page scripts -->
  <script src="scripts/forms/plugins.js" type="text/javascript" ></script>
  <script type="text/javascript" >
            
      var timerRefresh;
      var refreshInterval = 60000;
      function setRefreshMonitoring()
      {          
          timerRefresh = setTimeout(updateMonitoring, refreshInterval);
      } setRefreshMonitoring();

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
  <!--end initialize page scripts -->
</asp:Content>
