<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterAlarmMonitoringContainer.master" CodeFile="frmAlarmMonitoringView.aspx.vb" Inherits="frmAlarmMonitoringView" %>
<asp:Content ID="Monitoring_Content" ContentPlaceHolderID="Monitoring_Content" runat="server">
    <link rel="stylesheet" href="vendor/sweetalert/dist/sweetalert.css">

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

    <div class="row">
        <div class="col-sm-6  table-responsive">  
              <table class="table m-b">
                <thead>
                  <tr>
                    <th colspan="2" class="h4 text-left">Kiosk Info</th>                   
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <td>
                      <span></span>Computer Name :</td>
                    <td class="h5 col-sm-6"><asp:Label ID="lblComputerName" runat="server"></asp:Label></td>                    
                  </tr>
                 <tr>
                    <td>
                      <span></span>Location :</td>
                    <td class="h5 col-sm-6"><asp:Label ID="lblLocation" runat="server"></asp:Label></td>                    
                  </tr>
                    <tr>
                    <td>
                      <span></span>IP Address :</td>
                    <td class="h5 col-sm-6"><asp:Label ID="lblIPAddress" runat="server"></asp:Label></td>                    
                  </tr>
                    <tr>
                    <td>
                      <span></span>Mac Address :</td>
                    <td class="h5 col-sm-6"><asp:Label ID="lblMacAddress" runat="server"></asp:Label></td>                    
                  </tr>
                </tbody>
              </table>
                         
         </div>
          <div class="col-md-6">
            <div class="card bg-white">
                <div class="row m-a-0 m-t text-uppercase bold mobile_group_head m-b h5 text-center">
                    Today Avaliable
                </div>
                <div class="card-block text-center p-t-0 p-b-0">
                    <div class="piechart">
                        <div id="avaliablepie" runat="server" data-percent="0">
                            <div>
                                <div class="percent h1"></div>
                            </div>
                        </div>
                    </div>
                </div>
              
            </div>
        </div>
    </div>
 
   <div class="row">
       <div class="card bg-white">
           <br />
           <div class="row m-a-0 text-uppercase bold mobile_group_head m-b h4">
                Locker Information
           </div>
           <asp:Literal id="ltrlockerinfo" runat="server"></asp:Literal>
           <br />
        </div>
   </div>

    <div class="row">
        <div class="col-md-6 ">
            <div class="row col-sm-6 m-a-0 text-uppercase bold mobile_group_head m-b h4">
                PERIPHERAL CONDITION
            </div>
            <div class="row demo-button">
                <asp:Repeater ID="rptDevice" runat="server">
                    <ItemTemplate>

                        <span class="btn-success col-sm-6 h7 text-left" title="Coin In" id="spanDevice" runat="Server">
                            <asp:Image ID="iconDevice" runat="server" Width="30px" />
                            <asp:Label ID="lblDeviceName" runat="Server"></asp:Label>
                            <asp:Image ID="imgWarning" runat="server" CssClass="pull-right h-6" ImageUrl="~/images/warning.gif" Style="position: relative; width: 20px;" />
                            <asp:Label ID="lblStatus" runat="Server" CssClass="pull-right"></asp:Label>
                        </span>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

        <div class="col-md-6 ">
            <div class="row col-sm-6 m-a-0 text-uppercase bold mobile_group_head m-b h4" >
                Money Stock
            </div>

            <asp:Repeater ID="rptMoney" runat="server">
                <ItemTemplate>
                    <div class="col-sm-6" id="divAll" runat="server">
                        <div class="row m-a-0 text-success" id="divContainer" runat="server">
                            <i class="fa fa-circle"></i>
                            <asp:Label ID="lblName" runat="server"></asp:Label>
                            Level
                        <span class="pull-right">
                            <asp:Label ID="lblLevel" runat="server"></asp:Label></span>
                        </div>
                        <div class="progress">
                            <div class="progress-bar progress-bar-success" role="progressbar" id="progress" runat="server"></div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


            <div class="row col-sm-12 m-a-0 text-uppercase bold mobile_group_head m-t m-b h4">
                Printing Paper
            </div>

            <asp:Repeater ID="rptPrinter" runat="server">
                <ItemTemplate>
                    <div class="col-sm-6" id="divAll" runat="server">
                        <div class="row m-a-0 text-success" id="divContainer" runat="server">
                            <i class="fa fa-circle"></i>
                            <asp:Label ID="lblName" runat="server"></asp:Label>
                            Level
                            <span class="pull-right">
                                <asp:Label ID="lblLevel" runat="server"></asp:Label></span>
                        </div>
                        <div class="progress">
                            <div class="progress-bar progress-bar-success" role="progressbar" id="progress" runat="server"></div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <asp:Button ID="btnUpdateStatus" runat="server" Style="display: none;" ClientIDMode="Static" />
    </div>

       


    <div class="row">
        <div class="card bg-white">
            <br />
           <div class="row m-a-0 text-uppercase bold mobile_group_head m-b h4">
                Computer Usage Information
           </div>

            <div class="col-md-4 ">
                <div class="card bg-white">
                    <div class="row m-a-0 m-t text-uppercase bold mobile_group_head m-b h5 text-center">
                        CPU Usage
                    </div>
                    <div class="card-block text-center p-t-0 p-b-0">
                        <div class="piechart">
                            <div id="CPUPie" runat="server" data-percent="0">
                                <div>
                                    <div class="percent h1"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="col-md-4 ">
                <div class="card bg-white">
                    <div class="row m-a-0 m-t text-uppercase bold mobile_group_head m-b h5  text-center">
                        RAM Usage
                    </div>
                    <div class="card-block text-center p-t-0 p-b-0">
                        <div class="piechart">
                            <div id="RAMPie" runat="server" data-percent="0">
                                <div>
                                    <div class="percent h1"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-4 ">
                <div class="card bg-white">
                    <div class="row m-a-0 m-t text-uppercase bold mobile_group_head m-b h5  text-center">
                        DISK USAGE
                    </div>
                    <div class="card-block text-center p-t-0 p-b-0">
                        <div class="piechart">
                            <div id="DrivePie" runat="server" data-percent="0">
                                <div>
                                    <div class="percent h1"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



     
   </ContentTemplate>
</asp:UpdatePanel>  

</asp:Content>

<asp:Content ContentPlaceHolderID="ScriptContainer" ID="ScriptContainer" runat="server">
    
    <!-- page scripts -->
    <script src="vendor/jquery.easy-pie-chart/dist/jquery.easypiechart.js"></script>

    <script src="vendor/sweetalert/dist/sweetalert.min.js"></script>
    <!-- end page scripts -->
    <!-- initialize page scripts -->
    <script type="text/javascript">
        function renderPie(pieID,pieColor,percentValue,animate)
        {
            $('#' + pieID).attr('data-percent', percentValue);
            $('#' + pieID).easyPieChart({
                size: 180,
                lineWidth: 15,
                barColor: pieColor,
                trackColor: 'rgba(0,0,0,.1)',
                lineCap: 'butt',
                animate: animate,
                easing: 'easeOutBounce',
                onStep: function (from, to, percent) {
                    $(this.el).find('.percent').text(Math.round(percent));
                }
            });

            $('.piechart').each(function () {
                var canvas = $(this).find('canvas');
                $(this).css({
                    'width': canvas.width(),
                    'height': canvas.height()
                });
            });
        }


        function ShowDialogProfile(LockerName, TextInfo) {
            swal({
                title: LockerName,
                text: TextInfo,
                html: true,
                width: '500px'
            });
        }
    </script>
    <!-- end initialize page scripts -->

</asp:Content>
