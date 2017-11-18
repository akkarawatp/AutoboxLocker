<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Master/MasterPage.Master"  CodeFile="Report_SummaryByLocation.aspx.vb" Inherits="Report_SummaryByLocation" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="HeaderContainer" ContentPlaceHolderID="HeaderContainer" runat="server">

<!-- page stylesheets -->
  <link rel="stylesheet" href="vendor/chosen_v1.4.0/chosen.min.css">
  <link rel="stylesheet" href="vendor/checkbo/src/0.1.4/css/checkBo.min.css" />
  <link rel="stylesheet" href="vendor/intl-tel-input/build/css/intlTelInput.css">
  <!-- end page stylesheets -->
  <style type="text/css">
        table.table-bordered tbody tr td
        {
            text-align:right;
            }
        table.table-bordered tbody tr td.center
        {
            text-align:center;
            }
        th
        {
            background-color:#eeeeee;
            }
            
    /*Check Screen To Hide/Show For Responsive Feature*/
        
    @media (max-width: 47em) {
      .product_margin{display:none;}
      .top_product_mode{display:none;} 
     }
        
  </style>

</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-title">
        <div class="title">Reports > Summary Report > By Location</div>
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
                    <label class="col-sm-3 control-label">Location</label>
                    <div class="col-sm-9">                      
                        <asp:DropDownList ID="ddlLocation" runat="server" CssClass="chosen form-control" style="width: 100%;"></asp:DropDownList>
                    </div>
                    </div>                    
                </div>
            </div>

            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                        <label class="col-sm-3 control-label">From</label>
                        <div class="col-sm-9">  
                            <asp:TextBox CssClass="form-control m-b" ID="txtStartDate" runat="server" placeholder="Start Date"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" 
                                 Format="MMM dd yyyy" TargetControlID="txtStartDate" PopupPosition="BottomLeft"></ajaxToolkit:CalendarExtender>
                        </div>
                    </div>
                </div>
                <div class="col-lg-6"> 
                    <div class="form-group">
                        <label class="col-sm-3 control-label-right">To</label>
                        <div class="col-sm-9">  
                            <asp:TextBox CssClass="form-control m-b" ID="txtEndDate" runat="server" placeholder="End Date"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server" 
                                 Format="MMM dd yyyy" TargetControlID="txtEndDate" PopupPosition="BottomLeft"></ajaxToolkit:CalendarExtender>
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
            <div class="no-more-tables">
                <table class="table table-bordered m-b-0">
                      <thead>
                        <tr>
                            <th rowspan="2" >Location</th>
                            <th rowspan="2">Date</th>
                            <th colspan="2">SR</th>
                            <th colspan="2">MR</th>
                            <th colspan="2">LR</th>
                            <th colspan="2"><b>TOTAL</b></th>
                        </tr>
                        <tr>
                            <th >Success</th>
                            <th >Service Amount</th>
                            <th >Success</th>
                            <th >Service Amount</th>
                            <th >Success</th>
                            <th >Service Amount</th>
                            <th ><b>Success</b></th>
                            <th ><b>Service Amount</b></th>
                        </tr>
                      </thead>
                      <tbody>
                          <asp:Repeater ID="rptList" runat="server">
                            <ItemTemplate>
                                <tr>                 
                                    <td data-title="Location" class="center"><asp:Label ID="lblLocation" runat="server"></asp:Label></td>
                                    <td data-title="Date" id="tdMode" runat="server" class="center"><asp:Label ID="lblDate" runat="server"></asp:Label></td>
                                
                                    <td data-title="Success" class="center"><asp:Label ID="lblSRSuccess" runat="server"></asp:Label></th>
                                    <td data-title="ServiceAmount" ><asp:Label ID="lblSRServiceAmount" runat="server"></asp:Label></td>
                                    <td data-title="Success" class="center"><asp:Label ID="lblMRSuccess" runat="server"></asp:Label></th>
                                    <td data-title="ServiceAmount" "><asp:Label ID="lblMRServiceAmount" runat="server"></asp:Label></td>
                                    <td data-title="Success" class="center"><asp:Label ID="lblLRSuccess" runat="server"></asp:Label></th>
                                    <td data-title="ServiceAmount" ><asp:Label ID="lblLRServiceAmount" runat="server"></asp:Label></td>
                                    
                                    <td data-title="TotalSuccess" class="center"><b><asp:Label ID="lblTotalSuccess" runat="server"></asp:Label></b></th>
                                    <td data-title="TotalServiceAmount" ><b><asp:Label ID="lblTotalServiceAmount" runat="server"></asp:Label></b></td>
                                </tr>
                             </ItemTemplate>                          
                          </asp:Repeater>   
                        <tr>
                            <td data-title="Sum" colspan="2" class="bold bg-default-light"><b>Total</b></td>

                            <td data-title="Success" class="center bold bg-default-light"><b><asp:Label ID="lblSumSRSuccess" runat="server"></asp:Label></b></th>
                            <td data-title="ServiceAmount" class="bold bg-default-light"><b><asp:Label ID="lblSumSRServiceAmount" runat="server"></asp:Label></b></td>
                            <td data-title="Success" class="center bold bg-default-light"><b><asp:Label ID="lblSumMRSuccess" runat="server"></asp:Label></b></th>
                            <td data-title="ServiceAmount" class="bold bg-default-light"><b><asp:Label ID="lblSumMRServiceAmount" runat="server"></asp:Label></b></td>
                            <td data-title="Success" class="center bold bg-default-light"><b><asp:Label ID="lblSumLRSuccess" runat="server"></asp:Label></b></td>
                            <td data-title="ServiceAmount" class="bold bg-default-light"><b><asp:Label ID="lblSumLRServiceAmount" runat="server"></asp:Label></b></td>

                            <td data-title="SumSuccess" class="center bold bg-default-light"><b><asp:Label ID="lblSumTotalSuccess" runat="server"></asp:Label></b></td>
                            <td data-title="SumServiceAmount" class="bold bg-default-light"><b><asp:Label ID="lblSumTotalServiceAmount" runat="server"></asp:Label></b></td>
                        </tr>                                             
                      </tbody>                
                </table>
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
