<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Master/MasterPage.Master"  CodeFile="Report_Transaction_Performance.aspx.vb" Inherits="Report_Transaction_Performance" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="HeaderContainer" ContentPlaceHolderID="HeaderContainer" runat="server">

<!-- page stylesheets -->
  <link rel="stylesheet" href="vendor/chosen_v1.4.0/chosen.min.css">
  <%--<link rel="stylesheet" href="vendor/jquery.tagsinput/src/jquery.tagsinput.css">--%>
  <link rel="stylesheet" href="vendor/checkbo/src/0.1.4/css/checkBo.min.css" />
  <link rel="stylesheet" href="vendor/intl-tel-input/build/css/intlTelInput.css">
  <%--<link rel="stylesheet" href="vendor/bootstrap-daterangepicker/daterangepicker-bs3.css">
  <link rel="stylesheet" href="vendor/bootstrap-datepicker/dist/css/bootstrap-datepicker3.css">
  <link rel="stylesheet" href="vendor/bootstrap-timepicker/css/bootstrap-timepicker.min.css">
  <link rel="stylesheet" href="vendor/clockpicker/dist/bootstrap-clockpicker.min.css">
  <link rel="stylesheet" href="vendor/mjolnic-bootstrap-colorpicker/dist/css/bootstrap-colorpicker.min.css">
  <link rel="stylesheet" href="vendor/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.min.css">
  <link rel="stylesheet" href="vendor/jquery-labelauty/source/jquery-labelauty.css" />
  <link rel="stylesheet" href="vendor/multiselect/css/multi-select.css">
  <link rel="stylesheet" href="vendor/ui-select/dist/select.css">
  <link rel="stylesheet" href="vendor/select2/dist/css/select2.css">
  <link rel="stylesheet" href="vendor/selectize/dist/css/selectize.css">--%>
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
        <div class="title">Reports > Transaction Performance</div>
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
                
                <div class="col-lg-5">
                   <div class="form-group">
                    <label class="col-sm-2 control-label">By</label>
                    <div class="col-sm-10">
                            <div class="btn-group btn-group-justified">
                              <asp:LinkButton id="aByHour" runat="server" CssClass="btn btn-success">Hourly</asp:LinkButton>
                              <asp:LinkButton id="aByDay" runat="server" CssClass="btn btn-default">Daily</asp:LinkButton>
                              <asp:LinkButton id="aByMonth" runat="server" CssClass="btn btn-default">Monthly</asp:LinkButton>
                              <asp:LinkButton id="aByYear" runat="server" CssClass="btn btn-default">Yearly</asp:LinkButton>                             
                            </div>                                           
                    </div>
                  </div>                    
                </div>                    
        
                <asp:Panel CssClass="col-lg-6 m-t" ID="pnlFromDate" runat="server" visible="False">
                   <div class="form-group">
                    <label class="col-sm-3 control-label">From</label>
                    <div class="col-sm-9">  
                        <asp:TextBox CssClass="form-control m-b" ID="txtStartDate" runat="server" placeholder="Start Date"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server" 
                             Format="MMM dd yyyy" TargetControlID="txtStartDate" PopupPosition="BottomLeft"></ajaxToolkit:CalendarExtender>
                    </div>
                  </div>                    
                </asp:Panel>

                <asp:Panel CssClass="col-lg-5 m-t" ID="pnlToDate" runat="server" visible="False">
                   <div class="form-group">
                    <label class="col-sm-2 control-label">To</label>
                    <div class="col-sm-10">  
                        <asp:TextBox CssClass="form-control m-b" ID="txtEndDate" runat="server" placeholder="End Date"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server" 
                             Format="MMM dd yyyy" TargetControlID="txtEndDate" PopupPosition="BottomLeft"></ajaxToolkit:CalendarExtender>
                    </div>
                  </div>                    
                </asp:Panel>

                <asp:Panel CssClass="col-lg-6 m-t" ID="pnlFromMonth" runat="server" visible="False">
                   <div class="form-group">
                    <label class="col-sm-3 control-label">From</label>
                    <div class="col-sm-9">  
                        <asp:DropDownList ID="ddlFromMonth" runat="server" CssClass="chosen form-control" style="width: 100%;"></asp:DropDownList>
                    </div>
                  </div>                    
                </asp:Panel>

                <asp:Panel CssClass="col-lg-5 m-t" ID="pnlToMonth" runat="server" visible="False">
                   <div class="form-group">
                    <label class="col-sm-2 control-label">To</label>
                    <div class="col-sm-10">  
                         <asp:DropDownList ID="ddlToMonth" runat="server" CssClass="chosen form-control" style="width: 100%;"></asp:DropDownList>
                    </div>
                  </div>                    
                </asp:Panel>

                <asp:Panel CssClass="col-lg-6 m-t" ID="pnlFromYear" runat="server" visible="False">
                   <div class="form-group">
                    <label class="col-sm-3 control-label">From</label>
                    <div class="col-sm-9">  
                        <asp:DropDownList ID="ddlFromYear" runat="server" CssClass="chosen form-control" style="width: 100%;"></asp:DropDownList>
                    </div>
                  </div>                    
                </asp:Panel>

                <asp:Panel CssClass="col-lg-5 m-t" ID="pnlToYear" runat="server" visible="False">
                   <div class="form-group">
                    <label class="col-sm-2 control-label">To</label>
                    <div class="col-sm-10">  
                        <asp:DropDownList ID="ddlToYear" runat="server" CssClass="chosen form-control" style="width: 100%;"></asp:DropDownList>
                    </div>
                  </div>                    
                </asp:Panel>
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                    <label class="col-sm-3 control-label">Transaction Type</label>
                    <div class="col-sm-9">                      
                        <div class="btn-group btn-group-justified">
                            <asp:LinkButton id="rdiTransDeposit" runat="server" CssClass="btn btn-success" role="D"><i class="fa fa-check"></i> DEPOSIT</asp:LinkButton>    
                            <asp:LinkButton id="rdiTransCollect" runat="server" CssClass="btn btn-warning" role="C"><i class="fa fa-times"></i> COLLECT</asp:LinkButton>        
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
            <div class="no-more-tables">
                <table class="table table-bordered m-b-0">
                  <thead>
                    <tr>
                        <th><asp:Label ID="lblTimeDisplay" runat="server"></asp:Label></th>
                        <th>Location</th>
                        <th>Transaction Type</th>
                        <th>Success</th>
                        <th>Canceled</th>
                        <th>Problem</th>
                        <th>Timeout</th>
                        <th>Total</th>
                    </tr>
                  </thead>
                  <tbody>
                      <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>                 
                                <td data-title="Hour" id="tdMode" runat="server" class="center"><asp:Label ID="lblTime" runat="server"></asp:Label></td>
                                <td data-title="Location" class="center"><asp:Label ID="lblLocation" runat="server"></asp:Label></td>
                                <td data-title="TransactionType" class="center"><asp:Label ID="lblTransactionType" runat="server"></asp:Label></td>
                                <td data-title="Success"><asp:Label ID="lblTransSuccess" runat="server"></asp:Label></td>
                                <td data-title="Canceled"><asp:Label ID="lblTransCancel" runat="server"></asp:Label></td>                  
                                <td data-title="Problem"><asp:Label ID="lblTransProblem" runat="server"></asp:Label></td>
                                <td data-title="Timeout"><asp:Label ID="lblTransTimeout" runat="server"></asp:Label></td>
                                <td data-title="Total"><asp:Label ID="lblTransTotal" runat="server"></asp:Label></td>
                            </tr>
                         </ItemTemplate>                          
                      </asp:Repeater>  
                    <tr>
                        <td data-title="Average" colspan="3" style="background-color:#eeeeee; font-weight:bold;">Average</td>
                        <td data-title="Success" class="bold bg-default-light"><asp:Label ID="lbl_AVG_Trans_Success" runat="server"></asp:Label></td>
                        <td data-title="Canceled" class="bold bg-default-light"><asp:Label ID="lbl_AVG_Trans_Cancel" runat="server"></asp:Label></td>                  
                        <td data-title="Problem" class="bold bg-default-light"><asp:Label ID="lbl_AVG_Trans_Problem" runat="server"></asp:Label></td>
                        <td data-title="Timeout" class="bold bg-default-light"><asp:Label ID="lbl_AVG_Trans_Timeout" runat="server"></asp:Label></td>
                        <td data-title="Total" class="bold bg-default-light"><asp:Label ID="lbl_AVG_Trans_Total" runat="server"></asp:Label></td>
                    </tr>     
                    <tr>
                        <td data-title="Total" colspan="3" class="bold bg-default-light">Total</td>
                        <td data-title="Success" class="bold bg-default-light"><asp:Label ID="lbl_SUM_Trans_Success" runat="server"></asp:Label></td>
                        <td data-title="Canceled" class="bold bg-default-light"><asp:Label ID="lbl_SUM_Trans_Cancel" runat="server"></asp:Label></td>                  
                        <td data-title="Problem" class="bold bg-default-light"><asp:Label ID="lbl_SUM_Trans_Problem" runat="server"></asp:Label></td>
                        <td data-title="Timeout" class="bold bg-default-light"><asp:Label ID="lbl_SUM_Trans_Timeout" runat="server"></asp:Label></td>
                        <td data-title="Total" class="bold bg-default-light"><asp:Label ID="lbl_SUM_Trans_Total" runat="server"></asp:Label></td> 
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
