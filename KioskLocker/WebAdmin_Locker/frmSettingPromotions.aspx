<%@ Page Title="" Language="VB" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="false" CodeFile="frmSettingPromotions.aspx.vb" Inherits="frmSettingPromotions" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContainer" runat="server">
    <!-- page stylesheets -->
    <link rel="stylesheet" href="vendor/chosen_v1.4.0/chosen.min.css">
    <link rel="stylesheet" href="vendor/checkbo/src/0.1.4/css/checkBo.min.css" />
    <style type="text/css">
        @media (max-width: 47em) {
            .demo-button {
                text-align: center;
            }

                .demo-button .btn-success {
                    width: 45%;
                }

                .demo-button .btn-danger {
                    width: 45%;
                }

                .demo-button .btn-default {
                    width: 45%;
                }

            .mobile_group_head {
                padding-top: 10px;
                padding-bottom: 10px;
                text-align: center;
            }
        }

        @media (min-width: 48em) {
            .mobile_product div span {
                text-align: center;
                overflow: hidden;
            }
        }

        .condition {
            border: 1px solid white;
        }

        .uppercase {
            text-transform: uppercase;
        }
    </style>
    <script type="text/javascript">
       function NumberOnly() {
           var AsciiValue = event.keyCode
           if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
               event.returnValue = true;
           else
               event.returnValue = false;
       }
      
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-title">
        <div class="title">Master Data > Promotions</div>
        <div class="sub-title"></div>
    </div>

    <asp:UpdatePanel ID="udpList" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlList" runat="server" CssClass="card bg-white" Visible="True">
                <div class="card-header">
                    Found :
                    <asp:Label ID="lblTotalList" runat="server"></asp:Label>
                    Condition(s)
                </div>
                <div class="card-block">
                    <div class="no-more-tables">
                        <table class="table table-bordered table-striped datatable responsive align-middle bordered">
                            <thead>
                                <tr>
                                    <th>PROMOTION CODE</th>
                                    <th>PROMOTION NAME</th>
                                    <th>COUNT LOCATION</th>
                                    <th>PERIOD</th>
                                    <th id="ColEdit" runat="server">Edit</th>
                                    <th id="ColPublish" runat="server">Publish</th>
                                    <th id="ColDelete" runat="server">Delete</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptList" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td data-title="PROMOTION CODE">
                                                <center><asp:Label ID="lblPromotionCode" runat="server"></asp:Label></center>
                                            </td>
                                            <td data-title="PROMOTION NAME" id="td" runat="server">
                                                <asp:Label ID="lblPromotionName" runat="server"></asp:Label></td>
                                            <td data-title="COUNT LOCATION" class="numeric">
                                                <center><asp:Label ID="lblCountLocation" runat="server"></asp:Label></center>
                                            </td>
                                            <td data-title="PERIOD">
                                                <center><asp:Label ID="lblPeriod" runat="server"></asp:Label></center>
                                            </td>
                                            <td data-title="Edit" class="numeric" id="ColEdit" runat="server">
                                                <center><asp:Button CssClass="btn btn-success" ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" /></center>
                                            </td>
                                            <td data-title="Publish" class="numeric" id="ColPublish" runat="server">
                                                <center><asp:Button CssClass="btn btn-primary" ID="btnPublish" runat="server" Text="Publish" CommandName="Publish"/></center>
                                            </td>
                                            <td data-title="Delete" class="numeric" id="ColDelete" runat="server">
                                                <center><asp:Button CssClass="btn btn-danger" ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" /></center>
                                            </td>
                                        </tr>
                                        <ajaxToolkit:ConfirmButtonExtender ID="cfmDelete" runat="server" TargetControlID="btnDelete" />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <div class="row">
                        <asp:LinkButton CssClass="btn btn-primary btn-icon loading-demo mr5 btn-shadow" ID="btnAdd" runat="server">
                  <i class="fa fa-plus-circle"></i>
                  <span>Add new Promotion</span>
                        </asp:LinkButton>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="udpEdit" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlEdit" runat="server" CssClass="card bg-white">
                <div class="card-header">
                    <asp:Label ID="lblEditMode" runat="server"></asp:Label>
                    Promotion
                </div>
                <div class="card-block">
                    <div class="row m-a-0">
                        <div class="col-lg-12 form-horizontal">
                            <h4 class="card-title">Promotion Info</h4>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">PROMOTION CODE</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtPROMOTIONCODE" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label">PROMOTION NAME</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtPROMOTIONNAME" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
                                </div>
                            </div>
                             <div class="form-group">
                                 <label class="col-sm-2 control-label">PERIOD FROM</label>
                                 <div class="col-sm-2">
                                     <asp:TextBox CssClass="form-control m-b" ID="txtStartDate" runat="server" placeholder="Start Date"></asp:TextBox>
                                     <ajaxToolkit:CalendarExtender ID="txtStartDate_CalendarExtender" runat="server"
                                         Format="dd/MM/yyyy" TargetControlID="txtStartDate" PopupPosition="BottomLeft"></ajaxToolkit:CalendarExtender>
                                 </div>
                                 <label class="col-sm-1 control-label">TO</label>
                                 <div class="col-sm-2">
                                      <asp:TextBox CssClass="form-control m-b" ID="txtEndDate" runat="server" placeholder="End Date"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="txtEndDate_CalendarExtender" runat="server"
                                                Format="dd/MM/yyyy" TargetControlID="txtEndDate" PopupPosition="BottomLeft"></ajaxToolkit:CalendarExtender>
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
                                                    <li class="" id="liTabLocation" runat="server">
                                                        <asp:LinkButton ID="btnTabLocation" runat="server">
                                                    <div class="iti-flag ru" style="float:left; margin-top:0px; margin-right:3px; cursor:pointer;"></div><h5><span style="cursor:pointer">Location List</span></h5>
                                                        </asp:LinkButton>
                                                    </li>
                                                </ul>
                                                <div style="padding: 0.9375rem;">
                                                    <asp:Panel ID="tabServiceRate" runat="server">
                                                       
                                                        <div class="form-group">
                                                            <div class="col-sm-6">
                                                                <table class="table table-bordered table-striped datatable responsive align-middle bordered">
                                                                    <thead>
                                                                        <tr>
                                                                            <th>HOUR</th>
                                                                            <asp:Repeater ID="rptRateHeadModel" runat="server">
                                                                                <ItemTemplate>
                                                                                    <th>
                                                                                        <asp:Label ID="lblRateHeadModelName" runat="server" CssClass="control-label" Text=""></asp:Label>
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
                                                                                        <asp:Label ID="lblServiceRateHour" runat="server" CssClass="control-label" Text=""></asp:Label>
                                                                                    </th>
                                                                                    <asp:Repeater ID="rptRateHourModel" runat="server">
                                                                                        <ItemTemplate>
                                                                                            <th>
                                                                                                <asp:Label ID="lblHourCabinetModelID" runat="server" Text="" CssClass="control-label" Visible="false"></asp:Label>
                                                                                                <asp:TextBox ID="txtServiceRate" runat="server" CssClass="control-label" MaxLength="4" Width="50px"></asp:TextBox>
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
                                                        
                                                    </asp:Panel>
                                                    <asp:Panel ID="tabLocation" runat="server">
                                                        <div class="form-group">
                                                                <div class="col-sm-12" style="padding-left:10px">
                                                                    <asp:Panel ID="TabLocationList" runat="server" Height="400px" ScrollBars="Auto">
                                                                        <table class="table table-bordered table-striped datatable responsive align-middle bordered">
                                                                            <thead>
                                                                                <tr>
                                                                                    <th id="Th1" runat="server">
                                                                                        <label class="col-sm-2 cb-checkbox cb-md" onclick="document.getElementById('btnCheckLocationAll').click();">
                                                                                            <asp:CheckBox ID="chkHeadLocation" runat="server" Style="width: 70px"></asp:CheckBox>

                                                                                        </label>
                                                                                    </th>
                                                                                    <th>LOCATION NAME</th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody>
                                                                                <asp:Repeater ID="rptLocationList" runat="server">
                                                                                    <ItemTemplate>
                                                                                        <tr>
                                                                                            <td data-title="Select" id="ColSelect" runat="server" >
                                                                                                <center>
                                                                                   <label class="col-sm-2 cb-checkbox cb-md">
                                                                                    <asp:CheckBox ID="chkItemLocation" runat="server"></asp:CheckBox>
                                                                                    </label>
                                                                
                                                                                    </center>
                                                                                            </td>
                                                                                            <td data-title="LOCATION NAME" style="width: 700px;">
                                                                                                <center><asp:Label ID="lblLocationID" runat="server" visible="false"></asp:Label></center>
                                                                                                <asp:Label ID="lblLocationName" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </ItemTemplate>
                                                                                </asp:Repeater>
                                                                            </tbody>
                                                                        </table>
                                                                    </asp:Panel>
                                                                    <asp:Button ID="btnCheckLocationAll" runat="server" ClientIDMode="Static" Style="display: none;" />
                                                               
                                                            </div>
                                                        </div>

                                                    </asp:Panel>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                           <%-- <div class="form-group" style="margin-left: -5px;">
                                <h4 class="card-title col-sm-2 control-label" style="text-align: left;">Active Status </h4>
                                <label class="col-sm-10 cb-checkbox cb-md">
                                    <asp:CheckBox ID="chkActive" runat="server" />
                                </label>
                            </div>--%>
                            <div class="form-group" style="text-align: right">
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
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContainer" runat="server">
    <!-- page scripts -->
    <script src="vendor/chosen_v1.4.0/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="vendor/jquery.tagsinput/src/jquery.tagsinput.js" type="text/javascript"></script>
    <script src="vendor/checkbo/src/0.1.4/js/checkBo.min.js" type="text/javascript"></script>
    <script src="vendor/intl-tel-input//build/js/intlTelInput.min.js" type="text/javascript"></script>
    <script src="vendor/moment/min/moment.min.js" type="text/javascript"></script>
    <script src="vendor/bootstrap-daterangepicker/daterangepicker.js" type="text/javascript"></script>
    <script src="vendor/bootstrap-datepicker/js/bootstrap-datepicker.js" type="text/javascript"></script>
    <script src="vendor/bootstrap-timepicker/js/bootstrap-timepicker.min.js" type="text/javascript"></script>
    <script src="vendor/clockpicker/dist/jquery-clockpicker.min.js" type="text/javascript"></script>
    <script src="vendor/mjolnic-bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js" type="text/javascript"></script>
    <script src="vendor/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.min.js" type="text/javascript"></script>
    <script src="vendor/select2/dist/js/select2.js" type="text/javascript"></script>
    <script src="vendor/selectize/dist/js/standalone/selectize.min.js" type="text/javascript"></script>
    <script src="vendor/jquery-labelauty/source/jquery-labelauty.js" type="text/javascript"></script>
    <script src="vendor/bootstrap-maxlength/bootstrap-maxlength.min.js" type="text/javascript"></script>
    <script src="vendor/typeahead.js/dist/typeahead.bundle.js" type="text/javascript"></script>
    <script src="vendor/multiselect/js/jquery.multi-select.js" type="text/javascript"></script>
    <!-- end page scripts -->
    <!-- initialize page scripts -->
    <script src="scripts/forms/plugins.js" type="text/javascript"></script>
    <script type="text/javascript">
            
      //var timerRefresh;
      //var refreshInterval = 15000;
      //function setRefreshMonitoring()
      //{          
      //    timerRefresh = setTimeout(updateMonitoring, refreshInterval);
      //} setRefreshMonitoring();

      //function updateMonitoring()
      //{          
      //    var btn = document.getElementById('btnUpdateStatus');
      //    if (btn)
      //    {
      //        btn.click();
      //        timerRefresh = setTimeout(updateMonitoring, refreshInterval);
      //    }
      //}

<%--      function CheckAll() {
          alert("1111");
          var item = document.getElementById("<%=chkItemKioskAlarm.ClientID %>");
          alert(item.length);
          for (i = 0; i < item.length; i++) {
              item[i].select();
          }

          return false;
      }--%>
    </script>
    <!--end initialize page scripts -->

</asp:Content>

