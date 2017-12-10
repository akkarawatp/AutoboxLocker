<%@ Page Title="" Language="VB" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="false" CodeFile="frmDashboardDetail.aspx.vb" Inherits="frmDashboardDetail" %>

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

      <%--Line--%>
        <div class="m-x-n-g m-t-n-g overflow-hidden">
          <div class="card m-b-0 bg-success-white p-a-md no-border">
            <h5 class="m-t-0">
              <span class="pull-right"><asp:Label ID="lblSalesValues" runat="server"></asp:Label> This week</span>
              <span>Sales Values</span>
              </h5>


              <asp:Chart ID="LineChart" runat="server" Width="1000px" BackColor="Transparent">
                  <Series>
                      <asp:Series Name="series1" ChartType="Line" ChartArea="MainChartArea" XValueMember="Dstr" YValueMembers="net_income" BorderWidth="5"></asp:Series>
                  </Series>

                  <ChartAreas>
                      <asp:ChartArea Name="MainChartArea"></asp:ChartArea>
                  </ChartAreas>
              </asp:Chart>

          </div>
          <div class="card bg-white no-border">
            <div class="row text-center">
              <div class="col-sm-3 col-xs-6 p-t">
                <h4 class="m-t-0 m-b-0"><asp:Label ID="lblDailySales" runat="server"></asp:Label></h4>
                <small class="text-muted bold">Daily Sales</small>
              </div>
              <div class="col-sm-3 col-xs-6 p-t">
                <h4 class="m-t-0 m-b-0"><asp:Label ID="lblWeeklySales" runat="server"></asp:Label></h4>
                <small class="text-muted bold">Weekly Sales</small>
              </div>
              <div class="col-sm-3 col-xs-6 p-t">
                <h4 class="m-t-0 m-b-0"><asp:Label ID="lblMonthlySales" runat="server"></asp:Label></h4>
                <small class="text-muted bold">Monthly Sales</small>
              </div>
              <div class="col-sm-3 col-xs-6 p-t">
                <h4 class="m-t-0 m-b-0"><asp:Label ID="lblYearlySales" runat="server"></asp:Label></h4>
                <small class="text-muted bold">Yearly Sales</small>
              </div>
            </div>
          </div>
        </div>

        <%--Bar--%>
        <div class="col-sm-6">
            <div class="card bg-white" id="BarBlock">
                <div class="card-block text-center p-t-0">
                    <h5 class="text-orange">Annual Service Transactions</h5>
                    <div class="chart bar" style="height: 200px"></div>
                    
                    <a href="javascript:;" class="btn btn-primary btn-xs" style="background-color:#36C3F2;">DEPOSIT</a>
                    <a href="javascript:;" class="btn btn-success btn-xs" >COLLECT</a>
                    <a href="javascript:;" class="btn btn-danger btn-xs">Lost Transaction</a>

                </div>
            </div>
        </div>

        <div class="col-md-6">
            <div class="card bg-white no-border"  id="NoticeBlock" style="overflow-y:auto;">
              <div class="p-a bb text-danger text-center">
                NOTIFICATIONS
              </div>
              <asp:Literal ID="lblNotificationList" runat="server"></asp:Literal>
            </div>            
          </div>

          <div class="col-md-12">
                <iframe id="barifram" runat="server" style="height:360px; border:none; width:100%"></iframe>
          </div>
        
     </div>
    <asp:Button ID="btnRefreshData" runat="server" style="display:none;" ClientIDMode="Static" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContainer" Runat="Server">
    
    <!-- page scripts -->
    <script src="vendor/Chart.js/Chart.min.js"></script>

   <%-- <script src="scripts/helpers/colors.js"></script> --%>  
    <script src="vendor/flot/jquery.flot.js"></script>
    <script src="vendor/flot/jquery.flot.resize.js"></script>
    <script src="vendor/flot/jquery.flot.categories.js"></script>
    <script src="vendor/flot/jquery.flot.stack.js"></script>
    <script src="vendor/flot/jquery.flot.time.js"></script>
    <script src="vendor/flot/jquery.flot.pie.js"></script>
    <script src="vendor/flot-spline/js/jquery.flot.spline.js"></script>
    <script src="vendor/flot.orderbars/js/jquery.flot.orderBars.js"></script>

    <!-- initialize page scripts -->
    <script src="scripts/Dashboard_Default.js" type="text/javascript"></script>
    <!-- end initialize page scripts -->

  <!-- page scripts -->
  <script src="vendor/d3/d3.min.js" charset="utf-8"></script>
  <script src="vendor/c3/c3.min.js"></script>
  <!-- end page scripts -->
  <!-- initialize page scripts -->
  <script src="scripts/charts/c3.js"></script>


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

