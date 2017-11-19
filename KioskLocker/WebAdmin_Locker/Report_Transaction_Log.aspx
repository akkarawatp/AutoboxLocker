<%@ Page Title="" Language="vb"  AutoEventWireup="true" MasterPageFile="~/Master/MasterPage.Master" CodeFile="Report_Transaction_Log.aspx.vb" Inherits="Report_Transaction_Log" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="HeaderContainer" ContentPlaceHolderID="HeaderContainer" runat="server">

<!-- page stylesheets -->
  <link rel="stylesheet" href="vendor/chosen_v1.4.0/chosen.min.css">
  <link rel="stylesheet" href="vendor/checkbo/src/0.1.4/css/checkBo.min.css" />
  <link rel="stylesheet" href="vendor/intl-tel-input/build/css/intlTelInput.css">
  <link rel="stylesheet" href="vendor/bootstrap-timepicker/css/bootstrap-timepicker.min.css">
  <!-- end page stylesheets -->
  <style type="text/css">
        table.table-bordered tbody tr td
        {
            text-align:right;
            padding-left:auto;
            padding-right:auto;
            }
        table.table-bordered tbody tr td.center
        {
            text-align:center;
            }
        th
        {
            background-color:#eeeeee;
            }        
        
        .table > thead > tr > th
        {
            vertical-align:top;
            }

      td {
          text-align:center;
      }

          td.left {
        text-align:left;
          }

      .table-bordered tr:hover td {
        background-color:mintcream;
      }

      .table-bordered tr td {
        background-color:transparent;
        cursor:pointer;
      }
        
    /*Check Screen To Hide/Show For Responsive Feature*/
        
    @media (max-width: 47em) {
      
     }        

     @media (min-width: 47em) {
          .no-more-tables {
                max-height:400px;
          }
     }  

  </style>

</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-title">
        <div class="title">Reports > Transaction Log</div>
    </div>
<asp:UpdatePanel ID="udpSearch" runat="server">
    <Triggers>
        <asp:PostBackTrigger ControlID="lnkExcel" />
    </Triggers>
<ContentTemplate>
    <div class="card bg-white">
        <div class="card-header">
            Display Condition
        </div>
        <div class="card-block">
            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                    <label class="col-sm-4 control-label-right">Location</label>
                    <div class="col-sm-8">                      
                        <asp:DropDownList ID="ddlLocation" runat="server" CssClass="chosen form-control" style="width: 100%;" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    </div>                    
                </div>
                
                <asp:Panel ID="pnlKiosk_On" runat="server" CssClass="col-lg-6">
                    <div class="form-group">
                    <label class="col-sm-4 control-label-right">Kiosk</label>
                    <div class="col-sm-8">                      
                        <asp:DropDownList ID="ddlKiosk" runat="server" CssClass="chosen form-control" style="width: 100%;"></asp:DropDownList>
                    </div>
                    </div>
                </asp:Panel>   
                 <asp:Panel ID="pnlKiosk_Off" runat="server" CssClass="col-lg-6">          
                    <div class="form-group">
                        <label class="col-sm-4 control-label-right" style="color:white;">Kiosk</label>
                        <div class="col-sm-8">                      
                           <input type="text"  style="visibility:hidden;" class="form-control"/>
                        </div>
                    </div>              
                </asp:Panel> 
            </div> 
            <div class="row">
                <div class="col-lg-6 m-t">
                    <div class="form-group">
                        <label class="col-sm-4 control-label-right">Deposit Transaction No</label>
                        <div class="col-sm-8">                      
                            <asp:TextBox CssClass="form-control" ID="txtDepositTransactionNo" PlaceHolder="Deposit Transaction No" runat="server" />
                        </div>
                    </div>                    
                </div>
                <div class="col-lg-6 m-t">
                    <div class="form-group">
                        <label class="col-sm-4 control-label-right">Collect Transaction No</label>
                        <div class="col-sm-8">                      
                            <asp:TextBox CssClass="form-control" ID="txtCollectTransactionNo" PlaceHolder="Collect Transaction No" runat="server" />
                        </div>
                    </div>                    
                </div>

                <div class="col-lg-6 m-t">
                    <div class="form-group">
                        <label class="col-sm-4 control-label-right">Deposit Status</label>
                        <div class="col-sm-8">                      
                            <asp:DropDownList ID="ddlDepositStatus" runat="server" CssClass="chosen form-control" style="width: 100%;">
                                <asp:ListItem Value="" Text="All Status" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Success"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Cancel"></asp:ListItem>
                                <asp:ListItem Value="5" Text="Cancel by Admin"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Problem"></asp:ListItem>
                                <asp:ListItem Value="4" Text="Timeout"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>                    
                </div>
                <div class="col-lg-6 m-t">
                    <div class="form-group">
                        <label class="col-sm-4 control-label-right">Collect Status</label>
                        <div class="col-sm-8">                      
                            <asp:DropDownList ID="ddlCollectStatus" runat="server" CssClass="chosen form-control" style="width: 100%;">
                                <asp:ListItem Value="" Text="All Status" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Success"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Cancel"></asp:ListItem>
                                <asp:ListItem Value="5" Text="Cancel by Admin"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Problem"></asp:ListItem>
                                <asp:ListItem Value="4" Text="Timeout"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>                    
                </div> 
                <div class="col-lg-6 m-t">
                    <div class="form-group">
                        <label class="col-sm-4 control-label-right">Locker Size</label>
                        <div class="col-sm-8">                      
                            <asp:DropDownList ID="ddlCabinetModel" runat="server" CssClass="chosen form-control" style="width: 100%;"></asp:DropDownList>
                        </div>
                    </div>                    
                </div> 

                <div class="col-lg-6 m-t">
                    <div class="form-group">
                        <label class="col-sm-4 control-label-right"></label>
                        <div class="col-sm-8">                      
                            
                        </div>
                    </div>                    
                </div>

                
            </div>
            <div class="row">
                <div class="col-lg-6 m-t">
                   <div class="form-group">
                    <label class="col-sm-4 control-label-right">From</label>
                    <div class="col-sm-4">  
                        <asp:TextBox CssClass="form-control m-b" ID="txtStartDate" runat="server" placeholder="Start Date"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" 
                             Format="MMM dd yyyy" TargetControlID="txtStartDate" PopupPosition="BottomLeft"></ajaxToolkit:CalendarExtender>
                    </div>
                    <div class="col-sm-4">
                        <div class="input-group">
                          <asp:TextBox CssClass="form-control time-picker" ID="txtTimeStart" runat="server" />
                          <span class="input-group-addon add-on">
                            <i class="fa fa-clock-o"></i>
                            </span>
                        </div>
                    </div>
                  </div>                    
                </div> 

                <div class="col-lg-6 m-t">
                   <div class="form-group">
                    <label class="col-sm-4 control-label-right">To</label>
                    <div class="col-sm-4">  
                        <asp:TextBox CssClass="form-control m-b" ID="txtEndDate" runat="server" placeholder="End Date"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server" 
                             Format="MMM dd yyyy" TargetControlID="txtEndDate" PopupPosition="BottomLeft"></ajaxToolkit:CalendarExtender>
                    </div>
                    <div class="col-sm-4">
                        <div class="input-group">
                          <asp:TextBox CssClass="form-control time-picker" ID="txtTimeEnd" runat="server" />
                          <span class="input-group-addon add-on">
                            <i class="fa fa-clock-o"></i>
                            </span>
                        </div>
                    </div>
                  </div>                    
                </div>
            </div>

            <div class="row">
                <asp:LinkButton CssClass="btn btn-primary btn-icon loading-demo mr5 m-t btn-shadow" ID="btnApply" runat="server">
                  <i class="fa fa-check"></i>
                  <span>Apply</span>
                </asp:LinkButton>
                <asp:LinkButton CssClass="btn btn-success btn-icon loading-demo mr5 m-t btn-shadow" ID="lnkExcel" runat="server">
                <i class="fa fa-table"></i>
                <span>Export to Excel</span>
                </asp:LinkButton>
            </div>
        </div>
    </div>
</ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="udpReport" runat="server">
<ContentTemplate>
    <div class="card bg-white"> 
         <div class="card-header">
            <asp:Label ID="lblHeader" runat="server" CssClass="h4"></asp:Label>
        </div>
        <div class="card-block">
            <div style="width:100%; overflow:auto;">
                <div class="no-more-tables">
                    <table class="table table-bordered m-b-0" >
                      <thead>
                        <tr>
                            <th rowspan="3">DEPOSIT TRANSACTION</th>
                            <th rowspan="3">Start Time</th>
                            <th rowspan="3">Deposit Status</th>
                            <th rowspan="3">Location</th>
                            <th rowspan="3">KIOSK</th>
                            <th rowspan="3">LOCKER</th>
                            <th rowspan="3">DEPOSIT AMOUNT</th>
                            
                            <%--<th rowspan="3">CUSTOMER NAME</th>
                            <th rowspan="3">BIRTH DATE</th>
                            <th rowspan="3">AGE</th>
                            <th rowspan="3">CARD TYPE</th>
                            <th rowspan="3">NATIONALITY</th>--%>

                            <th rowspan="3">PAID TIME</th>
                            <th rowspan="3">LAST ACTIVITY</th>

                            <th colspan="7" >Payment</th>
                            <th colspan="3" >Change</th>

                            <th rowspan="3">COLLECT TRANSACTION</th>
                            <th rowspan="3">Collect Time</th>
                            <th rowspan="3">Paid Time</th>
                            <th rowspan="3">Collect Status</th>
                            <th rowspan="3">CARD TYPE</th>
                            <th rowspan="3">Service Time</th>
                            <th rowspan="3">SERVICE AMOUNT</th>

                            <th colspan="7">Payment</th>
                            <th colspan="3">Change</th>
                        </tr>
                        <tr> 
                            <th colspan="2" >Coin</th>
                            <th colspan="5" >Banknote</th>
                            <th colspan="1" >Coin</th>
                            <th colspan="2" >Banknote</th>

                            <th colspan="2" >Coin</th>
                            <th colspan="5" >Banknote</th>
                            <th colspan="1" >Coin</th>
                            <th colspan="2" >Banknote</th>
                        </tr>

                        <tr>
                            <th >5</th>
                            <th >10</th>
                            <th >20</th>
                            <th >50</th>
                            <th >100</th>
                            <th >500</th>
                            <th >1000</th>
                            <th >5</th>
                            <th >20</th>
                            <th >100</th>

                            <th >5</th>
                            <th >10</th>
                            <th >20</th>
                            <th >50</th>
                            <th >100</th>
                            <th >500</th>
                            <th >1000</th>
                            <th >5</th>
                            <th >20</th>
                            <th >100</th>
                        </tr>
                      </thead>
                      <tbody>
                          <asp:Repeater ID="rptList" runat="server">
                            <ItemTemplate>
                                <tr>                 
                                    <td data-title="Deposit Transaction No" id="td1" runat="server"><asp:Label ID="lblDepositTransactionNo" runat="server"></asp:Label></td>
                                    <td data-title="Start Time" id="td2" runat="server" ><asp:Label ID="lblStartTime" runat="server"></asp:Label></td>
                                    <td data-title="Deposit Status" id="td3" runat="server" class="btn-success"><asp:Label ID="lblDepositStatus" runat="server" Font-Bold="true"></asp:Label></td>
                                    <td data-title="Location" id="td4" runat="server"><asp:Label ID="lblLocation" runat="server"></asp:Label></td>
                                    <td data-title="Kiosk" id="td5" runat="server"><asp:Label ID="lblKiosk" runat="server"></asp:Label></td>
                                    <td data-title="Locker" id="td6" runat="server"><asp:Label ID="lblLockerName" runat="server"></asp:Label></td>
                                    <td data-title="Deposit Amount" id="td7" runat="server"><asp:Label ID="lblDepositAmt" runat="server"></asp:Label></td>
                                    <td data-title="Deposit Paid Time" id="td8" runat="server"><asp:Label ID="lblDepositPaidTime" runat="server"></asp:Label></td>                          
                                    <td data-title="Last Activity" id="td9" runat="server"><asp:Label ID="lblLastActivity" runat="server"></asp:Label></td>
                                    <td data-title="Deposit Payment Coin5" id="td10" runat="server"><asp:Label ID="lblDepositPaymentCoin5" runat="server"></asp:Label></td>
                                    <td data-title="Deposit Payment Coin10" id="td11" runat="server"><asp:Label ID="lblDepositPaymentCoin10" runat="server"></asp:Label></td>
                                    <td data-title="Deposit Payment Banknote20" id="td12" runat="server"><asp:Label ID="lblDepositPaymentBanknote20" runat="server"></asp:Label></td>
                                    <td data-title="Deposit Payment Banknote50" id="td13" runat="server"><asp:Label ID="lblDepositPaymentBanknote50" runat="server"></asp:Label></td>
                                    <td data-title="Deposit Payment Banknote100" id="td14" runat="server"><asp:Label ID="lblDepositPaymentBanknote100" runat="server"></asp:Label></td>
                                    <td data-title="Deposit Payment Banknote500" id="td15" runat="server"><asp:Label ID="lblDepositPaymentBanknote500" runat="server"></asp:Label></td>
                                    <td data-title="Deposit Payment Banknote1000" id="td16" runat="server"><asp:Label ID="lblDepositPaymentBanknote1000" runat="server"></asp:Label></td>
                                    <td data-title="Deposit Change Coin5" id="td17" runat="server"><asp:Label ID="lblDepositChangeCoin5" runat="server"></asp:Label></td>
                                    <td data-title="Deposit Change Banknote20" id="td18" runat="server"><asp:Label ID="lblDepositChangeBanknote20" runat="server"></asp:Label></td>
                                    <td data-title="Deposit Change Banknote100" id="td19" runat="server"><asp:Label ID="lblDepositChangeBanknote100" runat="server"></asp:Label></td>
                                    
                                    <td data-title="Collect Transaction No" id="td20" runat="server"><asp:Label ID="lblCollectTransactionNo" runat="server"></asp:Label></td>
                                    <td data-title="Collect Time" id="td21" runat="server"><asp:Label ID="lblCollectTime" runat="server"></asp:Label></td>
                                    <td data-title="Paid Time" id="td22" runat="server"><asp:Label ID="lblCollectPaidTime" runat="server"></asp:Label></td>
                                    <td data-title="Collect Status" id="td23" runat="server"><asp:Label ID="lblCollectStatus" runat="server"></asp:Label></td>
                                    <td data-title="Collect By" id="td24" runat="server"><asp:Label ID="lblCollectBy" runat="server"></asp:Label></td>
                                    <td data-title="Service Time" id="td25" runat="server"><asp:Label ID="lblServiceTime" runat="server"></asp:Label></td>
                                    <td data-title="Service Amount" id="td26" runat="server"><asp:Label ID="lblServiceAmt" runat="server"></asp:Label></td>
                                    <td data-title="Collect Payment Coin5" id="td27" runat="server"><asp:Label ID="lblCollectPaymentCoin5" runat="server"></asp:Label></td>
                                    <td data-title="Collect Payment Coin10" id="td28" runat="server"><asp:Label ID="lblCollectPaymentCoin10" runat="server"></asp:Label></td>
                                    <td data-title="Collect Payment Banknote20" id="td29" runat="server"><asp:Label ID="lblCollectPaymentBanknote20" runat="server"></asp:Label></td>
                                    <td data-title="Collect Payment Banknote50" id="td30" runat="server"><asp:Label ID="lblCollectPaymentBanknote50" runat="server"></asp:Label></td>
                                    <td data-title="Collect Payment Banknote100" id="td31" runat="server"><asp:Label ID="lblCollectPaymentBanknote100" runat="server"></asp:Label></td>
                                    <td data-title="Collect Payment Banknote500" id="td32" runat="server"><asp:Label ID="lblCollectPaymentBanknote500" runat="server"></asp:Label></td>
                                    <td data-title="Collect Payment Banknote1000" id="td33" runat="server"><asp:Label ID="lblCollectPaymentBanknote1000" runat="server"></asp:Label></td>
                                    <td data-title="Collect Change Coin5" id="td34" runat="server"><asp:Label ID="lblCollectChangeCoin5" runat="server"></asp:Label></td>
                                    <td data-title="Collect Change Banknote20" id="td35" runat="server"><asp:Label ID="lblCollectChangeBanknote20" runat="server"></asp:Label></td>
                                    <td data-title="Collect Change Banknote100" id="td36" runat="server"><asp:Label ID="lblCollectChangeBanknote100" runat="server"></asp:Label></td>
                                </tr>      
                            </ItemTemplate>
                        </asp:Repeater>                        
                      </tbody>
                    </table>
                </div>
            </div>
          </div>
    </div>
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
  <script src="scripts/forms/plugins.js" type="text/javascript"></script>
  <!-- end initialize page scripts -->

</asp:Content>
