<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master/MasterPage.Master" CodeFile="frmSettingAlarm.aspx.vb" Inherits="frmSettingAlarm" %>
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
        <div class="title">Setting & Monitoring > Alarm Setting</div>
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
                      <th>GROUP CODE</th>
                      <th>GROUP NAME</th>
                      <th>COUNT ALARM</th>                       
                      <th>COUNT EMAIL</th>
                      <th id="ColEdit" runat="server">Edit</th>
                      <th id="ColDelete" runat="server">Delete</th>
                    </tr>
                  </thead>
                  <tbody>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>
                              <td Data-Title="GROUP CODE"><center><asp:Label ID="lblGroupCode" runat="server"></asp:Label></center></td>
                              <td Data-Title="GROUP NAME" id="td" runat="server"  ><asp:Label ID="lblGroupName" runat="server"></asp:Label></td>
                              <td Data-Title="COUNT ALARM"  class="numeric"><center><asp:Label ID="lblCountAlarm" runat="server"></asp:Label></center></td>
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
                    Alarm
                </div>
                <div class="card-block">
                    <div class="row m-a-0">
                        <div class="col-lg-12 form-horizontal">
                            <h4 class="card-title">Alarm Group Info</h4>
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

                            <h4 class="card-title">Alam List</h4>
                            <div class="form-group">
                            <div class="col-sm-12">
                                <asp:Panel id="TabKioskAlarm" runat="server" Height="400px" ScrollBars="Auto">                            
                                        <table class="table table-bordered table-striped datatable responsive align-middle bordered">
                                            <thead>
                                                <tr>
                                                    <th id="Th1" runat="server">
                                                    <label class="col-sm-10 cb-checkbox cb-md" onclick="document.getElementById('btnCheckKioskAll').click();" >
                                                     <asp:CheckBox ID="chkHeadKioskAlarm" runat="server" style="width:70px"></asp:CheckBox>
                                                     
                                                     </label>
                                                    </th>
                                                    <th>ALARM CODE</th>
                                                    <th>ALARM PROBLEM</th>
                                                    <th>ENG DESC</th>
                                                    <th>SMS MESSAGE</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rptKioskAlarm" runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td data-title="Select"  id="ColSelect" runat="server">
                                                                <center>
                                                               <label class="col-sm-10 cb-checkbox cb-md">
                                                                <asp:CheckBox ID="chkItemKioskAlarm" runat="server"></asp:CheckBox>
                                                                </label>
                                                                
                                                                </center>
                                                            </td>
                                                            <td data-title="ALARM CODE" style="width:150px">
                                                                <center><asp:Label ID="lblKioskAlamID" runat="server" visible="false"></asp:Label></center>
                                                                <center><asp:Label ID="lblKioskAlarmCode" runat="server"></asp:Label></center>
                                                            </td>
                                                            <td data-title="ALARM PROBLEM" >
                                                                <asp:Label ID="lblKioskAlarmProblem" runat="server"></asp:Label></td>
                                                            <td data-title="ENG DESC" class="numeric">
                                                                <asp:Label ID="lblKioskEngDesc" runat="server"></asp:Label>
                                                            </td>
                                                            <td data-title="SMS MESSAGE" >
                                                                <asp:Label ID="lblKioskSMSMessage" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>      
                                </asp:Panel>
                                <asp:Button ID="btnCheckKioskAll" runat="server" ClientIDMode="Static" style="display:none;" />
                            </div>
                            </div>
                            <h4 class="card-title">Kiosk Alarm</h4>
                            <div class="form-group">
                                <div class="card-block">
                                    <table class="table datatable responsive align-middle col-sm-12" style="font-size: medium;">
                                        <thead>
                                            <tr>
                                                <th style="width:20%">No.</th>
                                                <th style="width:50%">MAC ADDRESS</th>
                                                <th id="Th4" runat="server" style="width:30%">Delete</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptComputerAlarm" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><center><asp:Label ID="lblNo" runat="server"></asp:Label></center></td>
                                                        <td>
                                                            <center>
                                                            <table>
                                                            <tr>
                                                            <td>
                                                            <asp:TextBox ID="txtMAC1" runat="server" Width="40px" MaxLength="2" CssClass="form-control uppercase " style="text-align:center; display:inline; padding:0; " />-
                                                                </td>
                                                                <td>
                                                                <asp:TextBox ID="txtMAC2" runat="server" Width="40px" MaxLength="2" CssClass="form-control uppercase" style="text-align:center; display:inline; padding:0; " />-
                                                                </td>
                                                                <td>
                                                                <asp:TextBox ID="txtMAC3" runat="server"  Width="40px" MaxLength="2" CssClass="form-control uppercase" style="text-align:center; display:inline; padding:0; " />-
                                                                </td>
                                                                <td>
                                                                <asp:TextBox ID="txtMAC4" runat="server"  Width="40px" MaxLength="2" CssClass="form-control uppercase" style="text-align:center; display:inline; padding:0; " />-
                                                                </td>
                                                                <td>
                                                                <asp:TextBox ID="txtMAC5" runat="server"  Width="40px" MaxLength="2" CssClass="form-control uppercase" style="text-align:center; display:inline; padding:0; " />-
                                                                </td>
                                                                <td>
                                                                <asp:TextBox ID="txtMAC6" runat="server"  Width="40px" MaxLength="2" CssClass="form-control uppercase" style="text-align:center; display:inline; padding:0; " />
                                                                </td>
                                                                   </tr>

                                                            </table>
                                                         
                                                            </center>
                                                        </td>
                                                        <td id="ColDelete" runat="server">
                                                            <center>
                                                            <asp:Button CssClass="btn btn-danger" ID="btnDeleteComputer" runat="server" Text="Remove" CommandName="Delete" />
                                                            </center>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                    <div class="row">
                                        <asp:LinkButton CssClass="btn btn-primary btn-icon loading-demo mr5 btn-shadow" ID="lnkAddNewComputer" runat="server">
                                      <i class="fa fa-plus-circle"></i>
                                      <span>Add new computer</span>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        
                            <h4 class="card-title">Email Alarm</h4>
                            <div class="form-group">
                                <div class="card-block">
                                    <table class="table datatable responsive align-middle col-sm-12" style="font-size: medium;">
                                        <thead>
                                            <tr>
                                                <th style="width:20%">No.</th>
                                                <th style="width:50%">Email</th>
                                                <th id="Th6" runat="server" style="width:30%">Delete</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rptEmailAlarm" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><center><asp:Label ID="lblNo" runat="server"></asp:Label></center></td>
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
