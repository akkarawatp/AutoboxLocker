<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master/MasterPage.Master" CodeFile="frmSettingMailGroup.aspx.vb" Inherits="frmSettingMailGroup" %>
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
       .uppercase { text-transform: uppercase; }
         
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
        <div class="title">Reports > Mail Group Reports</div>
        <div class="sub-title"></div>
    </div>

<asp:UpdatePanel ID="udpList" runat="server">
   <ContentTemplate>
       <asp:Panel ID="pnlList" runat="server" CssClass="card bg-white" Visible="True">
          <div class="card-header">
            Found : <asp:Label ID="lblTotalList" runat="server"></asp:Label> Condition(s)
          </div>
          <div class="card-block">
            <div class="no-more-tables">
                <table class="table table-bordered table-striped datatable responsive align-middle bordered">
                  <thead>
                    <tr>              
                      <th>GROUP NAME</th>
                      <th>COUNT REPORT</th>                       
                      <th>COUNT LOCATION</th>                       
                      <th>COUNT EMAIL</th>
                      <th id="ColEdit" runat="server">Edit</th>
                      <th id="ColDelete" runat="server">Delete</th>
                    </tr>
                  </thead>
                  <tbody>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>
                              <%--<td Data-Title="GROUP CODE"><center><asp:Label ID="lblGroupCode" runat="server"></asp:Label></center></td>--%>
                              <td Data-Title="GROUP NAME" id="td" runat="server"  ><asp:Label ID="lblGroupName" runat="server"></asp:Label></td>
                              <td Data-Title="COUNT REPORT"  class="numeric"><center><asp:Label ID="lblCountReport" runat="server"></asp:Label></center></td>
                              <td Data-Title="COUNT LOCATION"  class="numeric"><center><asp:Label ID="lblCountLocation" runat="server"></asp:Label></center></td>
                              <td Data-Title="COUNT EMAIL" class="numeric"><center><asp:Label ID="lblCountEmail" runat="server"></asp:Label></center></td>
                              <td Data-Title="Edit" class="numeric" id="ColEdit" runat="server"> <center><asp:Button CssClass="btn btn-success" ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" /></center></td>
                              <td Data-Title="Delete" class="numeric" id="ColDelete" runat="server"><center><asp:Button CssClass="btn btn-danger" ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" /></center></td>
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
                  <span>Add new group</span>
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
                    Mail Group Reports
                </div>
                <div class="card-block">
                    <div class="row m-a-0">
                        <div class="col-lg-12 form-horizontal">
                            <h4 class="card-title">Mail Group Report Info</h4>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">GROUP CODE</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtGROUPCODE" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label">GROUP NAME</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtGROUPNAME" runat="server" CssClass="form-control" MaxLength="255"></asp:TextBox>
                                </div>
                               
                            </div>

                            <h4 class="card-title">Report List</h4>
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <asp:Panel ID="pnlReportList" runat="server" Height="350px" Width="700px" ScrollBars="Auto">
                                        <table class="table table-bordered table-striped datatable responsive align-middle bordered">
                                            <thead>
                                                <tr>
                                                    <th id="Th1" runat="server">
                                                        <label class="col-sm-10 cb-checkbox cb-md" onclick="document.getElementById('btnCheckReportAll').click();">
                                                            <asp:CheckBox ID="chkHeadReportList" runat="server" Style="width: 70px"></asp:CheckBox>

                                                        </label>
                                                    </th>
                                                    <th>REPORT NAME</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rptReportList" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td data-title="Select" id="ColSelect" runat="server">
                                                                <center>
                                                               <label class="col-sm-10 cb-checkbox cb-md">
                                                                <asp:CheckBox ID="chkItemReportList" runat="server"></asp:CheckBox>
                                                                </label>
                                                                
                                                                </center>
                                                            </td>

                                                            <td data-title="REPORT NAME">
                                                                <asp:Label ID="lblReportName" runat="server"></asp:Label>
                                                                <center><asp:Label ID="lblReportID" runat="server" visible="false"></asp:Label></center>
                                                            </td>

                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </asp:Panel>
                                    <asp:Button ID="btnCheckReportAll" runat="server" ClientIDMode="Static" Style="display: none;" />



                                    <h4 class="card-title">Location List</h4>
                                    <div class="form-group">
                                        <div class="col-sm-12">
                                            <asp:Panel ID="pnlLocationList" runat="server" Height="350px" Width="700px" ScrollBars="Auto">
                                                <table class="table table-bordered table-striped datatable responsive align-middle bordered">
                                                    <thead>
                                                        <tr>
                                                            <th id="Th2" runat="server">
                                                                <label class="col-sm-10 cb-checkbox cb-md" onclick="document.getElementById('btnCheckLocationAll').click();">
                                                                    <asp:CheckBox ID="chkHeadLocationList" runat="server" Style="width: 70px"></asp:CheckBox>

                                                                </label>
                                                            </th>
                                                            <th>LOCATION NAME</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:Repeater ID="rptLocationList" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td data-title="Select" id="ColSelect" runat="server">
                                                                        <center>
                                                               <label class="col-sm-10 cb-checkbox cb-md">
                                                                <asp:CheckBox ID="chkItemLocationList" runat="server"></asp:CheckBox>
                                                                </label>
                                                                
                                                                </center>
                                                                    </td>

                                                                    <td data-title="LOCATION NAME">
                                                                        <asp:Label ID="lblLocationName" runat="server"></asp:Label>
                                                                        <center><asp:Label ID="lblLocationID" runat="server" visible="false"></asp:Label></center>
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

                          

                                    <h4 class="card-title">Mail To</h4>
                                    <div class="form-group">
                                        <div class="card-block">
                                            <table class="table datatable responsive align-middle col-sm-12" style="font-size: medium;">
                                                <thead>
                                                    <tr>
                                                        <th style="width: 20%">No.</th>
                                                        <th style="width: 50%">Email</th>
                                                        <th id="Th6" runat="server" style="width: 30%">Delete</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:Repeater ID="rptEmailAlarm" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <center><asp:Label ID="lblNo" runat="server"></asp:Label></center>
                                                                </td>
                                                                <td>
                                                                    <center>
                                                              <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="100" ></asp:TextBox>

                                                           
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" style="color:red"
                                                                ControlToValidate="txtEmail" Display="Dynamic"
                                                                ErrorMessage="Invalid email format"
                                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="True">
                                                                </asp:RegularExpressionValidator>

                                                            </center>
                                                                </td>
                                                                <td id="ColDelete" runat="server">
                                                                    <center>
                                                            <asp:Button CssClass="btn btn-danger" ID="btnDeleteEmail" runat="server" Text="Remove" CommandName="Delete" />
                                                            </center>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tbody>
                                            </table>
                                            <div class="row">
                                                <asp:LinkButton CssClass="btn btn-primary btn-icon loading-demo mr5 btn-shadow" ID="lnkAddNewEmail" runat="server">
                                      <i class="fa fa-plus-circle"></i>
                                      <span>Add new email</span>
                                                </asp:LinkButton>

                                            </div>
                                        </div>
                                    </div>


                            
                            <div class="form-group" style="margin-left: -5px;">
                                <h4 class="card-title col-sm-2 control-label" style="text-align: left;">Active Status </h4>
                                <label class="col-sm-10 cb-checkbox cb-md">
                                    <asp:CheckBox ID="chkActive" runat="server" />
                                </label>
                            </div>
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
                    </div>
                </div>
            </asp:Panel>
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
