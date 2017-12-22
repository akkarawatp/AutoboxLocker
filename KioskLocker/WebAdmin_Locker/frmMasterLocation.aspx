<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master/MasterPage.Master" CodeFile="frmMasterLocation.aspx.vb" Inherits="frmMasterLocation" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="HeaderContainer" ContentPlaceHolderID="HeaderContainer" runat="server">
  <!-- page stylesheets -->
  <link rel="stylesheet" href="vendor/chosen_v1.4.0/chosen.min.css">
  <link rel="stylesheet" type="text/css" href="vendor/checkbo/src/0.1.4/css/checkBo.min.css" />
  <!-- end page stylesheets -->

  <style type="text/css">
        .numeric
           {
               text-align:center;
               }
  </style>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-title">
        <div class="title">Master Data > Location</div>
        <div class="sub-title"></div>
    </div>
<asp:UpdatePanel ID="udpList" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnlList" runat="server" CssClass="card bg-white" Visible="True">
            <div class="card-header">
                Found : <asp:Label ID="lblTotalList" runat="server"></asp:Label> Location(s)
            </div>
            <div class="card-block">
                <div class="no-more-tables">
                <table class="table table-bordered table-striped m-b-0">
                  <thead>
                    <tr>
                      <th>Location Code</th>
                      <th>Location Name</th>
                      <th>Total Kiosk(s)</th>
                      <th id="ColEdit" runat="server">Edit</th>
                      <th id="ColDelete" runat="server">Delete</th>
                    </tr>
                  </thead>
                  <tbody>
                  <asp:Repeater ID="rptList" runat="server">
                    <ItemTemplate>
                        <tr>                 
                          <td data-title="Location Code"><asp:Label ID="lblLocCode" runat="server"></asp:Label></td>
                          <td data-title="Location Name" id="td" runat="server" ><asp:Label ID="lblLocName" runat="server"></asp:Label></td>                         
                          <td data-title="Total Kiosk(s)" class="numeric"><asp:Label ID="lblKiosk" runat="server"></asp:Label></td>                  
                          <td data-title="Edit" id="ColEdit" runat="server"><asp:Button CssClass="btn btn-success" ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" /></td>
                          <td data-title="Delete" id="ColDelete" runat="server"><asp:Button CssClass="btn btn-danger" ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" /></td>
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
                      <span>Add new location</span>
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
                <asp:Label ID="lblEditMode" runat="server"></asp:Label> Location
            </div>
            <div class="card-block">
                <div class="row m-a-0">
                  <div class="col-lg-12 form-horizontal">
                      <h4 class="card-title">Location Info</h4>
                      <div class="form-group">
                        <label class="col-sm-2 control-label">Location Code</label>
                        <div class="col-sm-4">
                          <asp:TextBox ID="txtLocationCode" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>                      
                        </div>
                      </div>                  
                      <div class="form-group">
                        <label class="col-sm-2 control-label">Location Name</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtLocationName" runat="server" CssClass="form-control" MaxLength="200"></asp:TextBox>
                        </div>                                       
                      </div>

                      <div class="row">
                          <div class="col-sm-12">
                              <div class="card" style="border: 0.125rem solid #e4e4e4;">
                                  <div class="card-block p-a-0">
                                      <div class="box-tab m-b-0">
                                          <ul class="nav nav-tabs">                                    
                                            <li class="" id="liTabServiceRate" runat="server">
                                                <asp:LinkButton ID="btnTabServiceRate" runat="server">
                                                    <div class="iti-flag gb" style="float:left; margin-top:3px; margin-right:3px; cursor:pointer;"></div><h5><span style="cursor:pointer">Service Rate</span></h5>
                                                </asp:LinkButton>
                                            </li>
                                            <li class="" id="liTabPromotion" runat="server">
                                                <asp:LinkButton ID="btnTabPromotion" runat="server">
                                                    <div class="iti-flag ru" style="float:left; margin-top:0px; margin-right:3px; cursor:pointer;"></div><h5><span style="cursor:pointer">Promotion</span></h5>
                                                </asp:LinkButton>
                                            </li>                                                              
                                          </ul>
                                          <div style="padding: 0.9375rem;">
                                              <asp:Panel id="tabServiceRate" runat="server">
                                                  <div class="form-group">
                                                    <label class="col-sm-2 control-label ">Deposit</label>
                                                    <div class="col-sm-6">
                                                        <asp:Repeater ID="rptDepositCabinetModel" runat="server">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDepositCabinetModelID" runat="server" Text="" CssClass="control-label" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblDepositCabinetModelName" runat="server" CssClass="control-label" Text="" ></asp:Label>

                                                                <asp:TextBox ID="txtDepositRate" runat="server"  MaxLength="4" CssClass="control-label" Width="50px"></asp:TextBox>
                                                                &nbsp;&nbsp;&nbsp;
                                                            </ItemTemplate>
                                                        </asp:Repeater>         
                                                    </div>
                                                </div>
                                                  <div class="form-group">
                                                    <label class="col-sm-2 control-label">Service Rate</label>
                                                    <div class="col-sm-6">
                                                        <table class="table table-bordered table-striped datatable responsive align-middle bordered">
                                                            <thead>
                                                                <tr>
                                                                    <th>HOUR</th>
                                                                    <asp:Repeater ID="rptRateHeadModel" runat="server">
                                                                        <ItemTemplate>
                                                                            <th>
                                                                                <asp:Label ID="lblRateHeadModelName" runat="server" CssClass="control-label" Text="" ></asp:Label>
                                                                            </th>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <asp:Repeater ID="rptServiceRateHour" runat="server">
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <th>
                                                                                <asp:Label ID="lblServiceRateHour" runat="server" CssClass="control-label" Text="" ></asp:Label>
                                                                            </th>
                                                                            <asp:Repeater ID="rptRateHourModel" runat="server">
                                                                                <ItemTemplate>
                                                                                    <th>
                                                                                        <asp:Label ID="lblHourCabinetModelID" runat="server" Text="" CssClass="control-label" Visible="false"></asp:Label>
                                                                                        <asp:TextBox ID="txtServiceRate" runat="server" CssClass="control-label"  MaxLength="4" Width="50px"></asp:TextBox>
                                                                                    </th>
                                                                                </ItemTemplate>
                                                                            </asp:Repeater>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                  </div>
                                                  <div class="form-group">
                                                    <label class="col-sm-2 control-label">Next day</label>
                                                    <div class="col-sm-6">
                                                        <asp:Repeater ID="rptOvernightRate" runat="server">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOvernightCabinetModelID" runat="server" Text="" CssClass="control-label" Visible="false"></asp:Label>
                                                                <asp:Label ID="lblOvernightCabinetModelName" runat="server" CssClass="control-label" Text="" ></asp:Label>

                                                                <asp:TextBox ID="txtOvernightRate" runat="server" CssClass="control-label" MaxLength="4" Width="50px"></asp:TextBox>
                                                                &nbsp;&nbsp;&nbsp;
                                                            </ItemTemplate>
                                                        </asp:Repeater>                  
                                                    </div>
                                                  </div>
                                                  <div class="form-group">
                                                      <label class="col-sm-2 control-label">Fine</label>
                                                      <div class="col-sm-6">
                                                          <asp:Repeater ID="rptFineRate" runat="server">
                                                              <ItemTemplate>
                                                                  <asp:Label ID="lblFineCabinetModelID" runat="server" Text="" CssClass="control-label" Visible="false"></asp:Label>
                                                                  <asp:Label ID="lblFineCabinetModelName" runat="server" CssClass="control-label" Text="" ></asp:Label>
                                                                  <asp:TextBox ID="txtFineRate" runat="server" CssClass="control-label" MaxLength="4" Width="50px"></asp:TextBox>
                                                                  &nbsp;&nbsp;&nbsp;
                                                              </ItemTemplate>
                                                          </asp:Repeater>
                                                      </div>
                                                  </div>
                                              </asp:Panel>
                                              <asp:Panel ID="tabPromotion" runat="server">
                                                  <div class="form-group">
                                                      <asp:Panel ID="pnlPromotionDetail" runat="server" CssClass="card bg-white border-white">
                                                          <div class="row">
                                                              <div class="form-group" style="display: none;">
                                                                  <label class="col-sm-2 control-label">Promotion Code</label>
                                                                  <div class="col-sm-4">
                                                                      <asp:Label ID="lblLocationPromotionID" runat="server" Text="0" Visible="false"></asp:Label>
                                                                      <asp:Label ID="lblPublishStatus" runat="server" Text="0" Visible="false"></asp:Label>
                                                                      <asp:TextBox ID="txtPromotionCode" runat="server" CssClass="form-control" MaxLength="20" Enabled="false"></asp:TextBox>
                                                                  </div>
                                                              </div>
                                                              <div class="form-group">
                                                                  <label class="col-sm-2 control-label">Promotion Name</label>
                                                                  <div class="col-sm-10">
                                                                      <asp:TextBox ID="txtPromotionName" runat="server" CssClass="form-control" MaxLength="200" Enabled="false"></asp:TextBox>
                                                                  </div>
                                                              </div>
                                                          </div>
                                                          <div class="row">
                                                              <div class="form-group">
                                                                  <label class="col-sm-2 control-label">Promotion Period</label>
                                                                  <label class="col-sm-1 control-label-right">From</label>
                                                                  <div class="col-sm-2">
                                                                      <asp:TextBox CssClass="form-control m-b" ID="txtPromotionStartDate" runat="server" placeholder="Start Date" Enabled="false"></asp:TextBox>
                                                                      <ajaxToolkit:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server"
                                                                          Format="MMM dd yyyy" TargetControlID="txtPromotionStartDate" PopupPosition="BottomLeft"></ajaxToolkit:CalendarExtender>
                                                                  </div>
                                                                  <label class="col-sm-1 control-label-right">To</label>
                                                                  <div class="col-sm-2">
                                                                      <asp:TextBox CssClass="form-control m-b" ID="txtPromotionEndDate" runat="server" placeholder="End Date" Enabled="false"></asp:TextBox>
                                                                      <ajaxToolkit:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server"
                                                                          Format="MMM dd yyyy" TargetControlID="txtPromotionEndDate" PopupPosition="BottomLeft"></ajaxToolkit:CalendarExtender>
                                                                  </div>
                                                              </div>
                                                          </div>
                                                          <div class="row">
                                                              <div class="no-more-tables">
                                                                  <label class="col-sm-2 control-label">Promotion Rate</label>
                                                                  <div class="col-sm-6">
                                                                      <table class="table table-bordered table-striped datatable responsive align-middle bordered">
                                                                          <thead>
                                                                              <tr>
                                                                                  <th>HOUR</th>
                                                                                  <asp:Repeater ID="rptPromotionRate" runat="server">
                                                                                      <ItemTemplate>
                                                                                          <th>
                                                                                              <asp:Label ID="lblPromotionRateHeadModelName" runat="server" CssClass="control-label" Text=""></asp:Label>
                                                                                          </th>
                                                                                      </ItemTemplate>
                                                                                  </asp:Repeater>
                                                                              </tr>
                                                                          </thead>
                                                                          <tbody>
                                                                              <asp:Repeater ID="rptPromotionRateHour" runat="server">
                                                                                  <ItemTemplate>
                                                                                      <tr>
                                                                                          <th>
                                                                                              <asp:Label ID="lblPromotionRateHour" runat="server" CssClass="control-label" Text=""></asp:Label>
                                                                                          </th>
                                                                                          <asp:Repeater ID="rptPromotionRateHourModel" runat="server">
                                                                                              <ItemTemplate>
                                                                                                  <th>
                                                                                                      <asp:Label ID="lblPromotionHourCabinetModelID" runat="server" Text="" CssClass="control-label" Visible="false"></asp:Label>
                                                                                                      <asp:TextBox ID="txtPromotionRate" runat="server" CssClass="control-label" MaxLength="4" Width="50px" Enabled="false"></asp:TextBox>
                                                                                                  </th>
                                                                                              </ItemTemplate>
                                                                                          </asp:Repeater>
                                                                                      </tr>
                                                                                  </ItemTemplate>
                                                                              </asp:Repeater>
                                                                          </tbody>
                                                                      </table>
                                                                  </div>
                                                              </div>
                                                          </div>
                                                          <div class="row">
                                                              <label class="col-sm-2 control-label"></label>
                                                              <div class="col-sm-6">
                                                                  <asp:LinkButton CssClass="btn btn-primary btn-icon loading-demo mr5 btn-shadow" ID="likPublishPromotion" runat="server">
                                                                  <i class="fa fa-angle-double-up"></i>
                                                                  <span>Publish</span>
                                                                  </asp:LinkButton>
                                                              </div>
                                                          </div>
                                                      </asp:Panel>
                                                      <div class="row">
                                                          <h4 class="card-title">&nbsp;&nbsp;&nbsp;Promotion History</h4>

                                                          <div class="card-block">
                                                              <div class="no-more-tables">
                                                                  <table class="table table-bordered table-striped m-b-0">
                                                                      <thead>
                                                                          <tr>
                                                                              <th style="width: 180px">Promotion Code</th>
                                                                              <th>Promotion Name</th>
                                                                              <th style="width: 200px">Promotion Period</th>
                                                                              <th style="width: 100px" id="pListTh1" runat="server">Edit</th>
                                                                              <th style="width: 100px" id="pListTh2" runat="server">Publish</th>
                                                                              <th style="width: 100px" id="pListTh3" runat="server">Delete</th>
                                                                          </tr>
                                                                      </thead>
                                                                      <tbody>
                                                                          <asp:Repeater ID="rptPromotionHis" runat="server">
                                                                              <ItemTemplate>
                                                                                  <tr id="pTr" runat="server">
                                                                                      <td data-title="Promotion Code" style="text-align: center">
                                                                                          <asp:Label ID="lblPromotionCode" runat="server"></asp:Label></td>
                                                                                      <td data-title="Promotion Name">
                                                                                          <asp:Label ID="lblPromotionName" runat="server"></asp:Label></td>
                                                                                      <td data-title="Promotion Period">
                                                                                          <asp:Label ID="lblPromotionPeriod" runat="server"></asp:Label></td>
                                                                                      <td data-title="Edit" id="ColPromotionEdit" runat="server">
                                                                                          <asp:Button CssClass="btn btn-success" ID="btnPromotionEdit" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("id") %>' ></asp:Button></td>
                                                                                      <td data-title="Publish" id="ColPromotionPublish" runat="server">
                                                                                          <asp:Button CssClass="btn btn-primary" ID="btnPromotionPublish" runat="server" Text="Publish" CommandName="Publish" CommandArgument='<%# Eval("id") %>'  ></asp:Button></td>
                                                                                      <td data-title="Delete" id="ColPromotionDelete" runat="server">
                                                                                          <asp:Button CssClass="btn btn-danger" ID="btnPromotionDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("id") %>' ></asp:Button></td>
                                                                                  </tr>
                                                                                  <ajaxToolkit:ConfirmButtonExtender ID="cfmPromotionDelete" runat="server" TargetControlID="btnPromotionDelete" />
                                                                              </ItemTemplate>
                                                                          </asp:Repeater>
                                                                      </tbody>
                                                                  </table>
                                                              </div>
                                                          </div>
                                                      </div>
                                                  </div>
                                              </asp:Panel>
                                          </div>
                                      </div>
                                  </div>
                              </div>
                          </div>
                      </div>

                      <div class="form-group" style="margin-left:-5px;">
                            <h4 class="card-title col-sm-2 control-label" style="text-align:left;">Active Status </h4>  
                        
                            <label class="col-sm-10 cb-checkbox cb-md">
                                <asp:CheckBox ID="chkActive" runat="server" Checked="true" />
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
  <script src="scripts/forms/plugins.js" type="text/javascript"></script>
  <!-- end initialize page scripts -->
</asp:Content>
