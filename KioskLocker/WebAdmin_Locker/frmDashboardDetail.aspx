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
        <div class="m-x-n-g m-t-n-g overflow-hidden">
            <div class="card m-b-0 bg-success-white p-a-md no-border">
                <h5 class="m-t-0">
                    <span class="pull-right">
                        <asp:Label ID="lblSalesValues" runat="server"></asp:Label>
                        This week</span>
                    <span>
                        <asp:Label ID="lblLocationName" runat="server"></asp:Label></span>
                </h5>
            </div>

            <div class="card bg-white no-border">
                <div class="row">
                    <div class="col-sm-1">
                    </div>
                    <asp:Repeater ID="rtpWeekIncomeSection" runat="server">
                        <ItemTemplate>
                            <div class="col-sm-2 col-xs-6">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div class="card no-border bg-orange align-middle text-center" style="padding: 0.75rem">
                                            <h4 class="m-a-0 bold">Week
                                                <asp:Label ID="lblWeekNo" runat="server"></asp:Label>
                                            </h4>
                                        </div>
                                    </div>
                                </div>
                                <table class="table table-bordered m-b-0">
                                    <tbody>
                                        <asp:Repeater ID="rptWeekDetail" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class="text-left" style="padding: 0.625rem 0.5rem">
                                                        <asp:Label ID="lblPickupDate" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="text-right" style="padding: 0.625rem 0.5rem">
                                                        <asp:Label ID="lblIncome" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="col-sm-1">
                    </div>
                </div>
            </div>

            <div class="card bg-white no-border" style="padding: 10px">
                <div class="row">
                    <div class="col-sm-1">
                    </div>
                    <div class="col-sm-10">
                        <asp:Repeater ID="rptMonthIncome" runat="server">
                            <ItemTemplate>
                                <div class="col-sm-3">
                                    <div class="col-sm-7">
                                        <div class="card card-block no-border bg-orange row-equal align-middle" style="padding: 5px;">
                                            <h6 class="m-a-0 text-white">Month Income</h6>
                                            <h4 class="m-a-0 text-white">
                                                <asp:Label ID="lblMonthName" runat="server"></asp:Label>
                                            </h4>
                                        </div>
                                    </div>
                                    <div class="col-sm-5">
                                        <div class="card card-block bg-white row-equal align-middle" style="padding: 10px;">
                                            <h4 class="m-a-0">
                                                <asp:Label ID="lblMonthIncome" runat="server"></asp:Label>
                                            </h4>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="col-sm-1">
                    </div>
                </div>
            </div>

            <div class="card bg-white no-border">
                <div class="row text-center">
                    <div class="col-sm-3 col-xs-6 p-t">
                        <h4 class="m-t-0 m-b-0">
                            <asp:Label ID="lblDailySales" runat="server"></asp:Label>
                            ฿</h4>
                        <small class="text-muted bold">Daily Sales</small>
                    </div>
                    <div class="col-sm-3 col-xs-6 p-t">
                        <h4 class="m-t-0 m-b-0">
                            <asp:Label ID="lblWeeklySales" runat="server"></asp:Label>
                            ฿</h4>
                        <small class="text-muted bold">Weekly Sales</small>
                    </div>
                    <div class="col-sm-3 col-xs-6 p-t">
                        <h4 class="m-t-0 m-b-0">
                            <asp:Label ID="lblMonthlySales" runat="server"></asp:Label>
                            ฿</h4>
                        <small class="text-muted bold">Monthly Sales</small>
                    </div>
                    <div class="col-sm-3 col-xs-6 p-t">
                        <h4 class="m-t-0 m-b-0">
                            <asp:Label ID="lblYearlySales" runat="server"></asp:Label>
                            ฿</h4>
                        <small class="text-muted bold">Yearly Sales</small>
                    </div>
                </div>
            </div>

            <div class="card bg-white no-border" style="padding: 10px">
                <div class="row">
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-12">
                                <h5>Company Commission</h5>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="card card-block bg-white row-equal align-middle text-center" style="padding: 10px;">
                                    <h1>
                                        <asp:Label ID="lblGrossProfitRate" runat="server"></asp:Label>
                                        %</h1>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="card card-block no-border bg-orange row-equal align-middle" style="padding: 5px; margin-bottom: 0.5rem">
                                            <h6 class="m-a-0 text-white">Day Income</h6>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="card card-block bg-white row-equal align-middle" style="padding: 5px; margin-bottom: 0.5rem">
                                            <h6 class="m-a-0">
                                                <asp:Label ID="lblCompanyDayIncome" runat="server"></asp:Label>
                                                THB
                                            </h6>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="card card-block no-border bg-orange row-equal align-middle" style="padding: 5px; margin-bottom: 0.5rem">
                                            <h6 class="m-a-0 text-white">Week Income</h6>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="card card-block bg-white row-equal align-middle" style="padding: 5px; margin-bottom: 0.5rem">
                                            <h6 class="m-a-0">
                                                <asp:Label ID="lblCompanyWeekIncome" runat="server"></asp:Label>
                                                THB
                                            </h6>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="card card-block no-border bg-orange row-equal align-middle" style="padding: 5px; margin-bottom: 0.5rem">
                                            <h6 class="m-a-0 text-white">Month Income</h6>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="card card-block bg-white row-equal align-middle" style="padding: 5px; margin-bottom: 0.5rem">
                                            <h6 class="m-a-0">
                                                <asp:Label ID="lblCompanyMonthIncome" runat="server"></asp:Label>
                                                THB
                                            </h6>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-12">
                                <h5>Renter</h5>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="card card-block bg-white row-equal align-middle text-center" style="padding: 10px;">
                                    <h1>
                                        <asp:Label ID="lblRenterRate" runat="server"></asp:Label>
                                        %</h1>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="card card-block no-border bg-orange row-equal align-middle" style="padding: 5px; margin-bottom: 0.5rem">
                                            <h6 class="m-a-0 text-white">Day Income</h6>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="card card-block bg-white row-equal align-middle" style="padding: 5px; margin-bottom: 0.5rem">
                                            <h6 class="m-a-0">
                                                <asp:Label ID="lblRenterDayIncome" runat="server"></asp:Label>
                                                THB
                                            </h6>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="card card-block no-border bg-orange row-equal align-middle" style="padding: 5px; margin-bottom: 0.5rem">
                                            <h6 class="m-a-0 text-white">Week Income</h6>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="card card-block bg-white row-equal align-middle" style="padding: 5px; margin-bottom: 0.5rem">
                                            <h6 class="m-a-0">
                                                <asp:Label ID="lblRenterWeekIncome" runat="server"></asp:Label>
                                                THB
                                            </h6>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <div class="card card-block no-border bg-orange row-equal align-middle" style="padding: 5px; margin-bottom: 0.5rem">
                                            <h6 class="m-a-0 text-white">Month Income</h6>
                                        </div>
                                    </div>
                                    <div class="col-sm-6">
                                        <div class="card card-block bg-white row-equal align-middle" style="padding: 5px; margin-bottom: 0.5rem">
                                            <h6 class="m-a-0">
                                                <asp:Label ID="lblRenterMonthIncome" runat="server"></asp:Label>
                                                THB
                                            </h6>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-12">
                <iframe id="barifram" runat="server" style="height: 360px; border: none; width: 100%"></iframe>
            </div>
        </div>

    </div>
    <asp:Button ID="btnRefreshData" runat="server" style="display:none;" ClientIDMode="Static" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContainer" Runat="Server">
    
    <!-- page scripts -->
    <!-- <script src="vendor/Chart.js/Chart.min.js"></script> -->
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
  <!-- <script src="vendor/d3/d3.min.js" charset="utf-8"></script>-->
  <!-- <script src="vendor/c3/c3.min.js"></script>-->
  <!-- end page scripts -->
  <!-- initialize page scripts -->
  <!-- <script src="scripts/charts/c3.js"></script>-->


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

