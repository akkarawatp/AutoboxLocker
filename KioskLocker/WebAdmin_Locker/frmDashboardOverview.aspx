<%@ Page Title="" Language="VB" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="false" CodeFile="frmDashboardOverview.aspx.vb" Inherits="frmDashboardOverview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContainer" Runat="Server">
      <!-- page stylesheets -->
  <link rel="stylesheet" href="vendor/c3/c3.min.css">
  <!-- end page stylesheets -->

  <style type="text/css">
      .m-t-n-g {
        margin-top:-1.5rem !important;
      }

      .notifications .notifications-list li a {
        padding: 0.5rem;
      }
  </style>
  <script src="vendor/jquery/dist/jquery.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
        <div class="col-lg-12">

            <asp:Repeater ID="rptList" runat="server">
                <ItemTemplate>
                    <div class="col-sm-4">  
                        <table class="table-responsive table m-b-1" >
                            <tr>
                                <th colspan="2" class="h4 text-left">
                                    <asp:LinkButton ID="lblLocationName" runat="server" ForeColor="#36c3f2"></asp:LinkButton>
                                </th>                   
                            </tr>
                            <tr>
                                <td class="col-sm-7">Daily Sales :</td>
                                <td class="h5 col-sm-5"><asp:Label ID="lblDailySales" runat="server"></asp:Label></td>                    
                            </tr>
                            <tr>
                                <td >Today's Deposite Success :</td>
                                <td ><asp:Label ID="lblDepositeSuccess" runat="server"></asp:Label></td>  
                            </tr>
                             <tr>
                                <td >Today's Collect Success :</td>
                                <td ><asp:Label ID="lblCollectSuccess" runat="server"></asp:Label></td> 
                            </tr>
                             <tr>
                                  <td >Remain :</td>
                                <td ><asp:Label ID="lblRemain" runat="server"></asp:Label></td> 
                            </tr>
                             <tr>
                                  <td >Status :</td>
                                <td ><asp:Label ID="lblStatus" runat="server"></asp:Label></td> 
                            </tr>
                   
                        </table>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            
        </div>
    </div>

    <asp:Button ID="btnRefreshData" runat="server" style="display:none;" ClientIDMode="Static" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContainer" Runat="Server">
    <script type="text/javascript" lang="javascript">

        var timerRefresh;
        var refreshInterval = 60000;  //อัพเดททุกๆ 1 นาที
        function setRefreshMonitoring() {
            timerRefresh = setTimeout(updateMonitoring, refreshInterval);
        }
        $(document).ready(function () {
            setRefreshMonitoring();
        });

        function updateMonitoring() {

            var btn = document.getElementById('btnRefreshData');
            if (btn) {
                btn.click();
                timerRefresh = setTimeout(updateMonitoring, refreshInterval);
            }
        }
    </script>
</asp:Content>

