<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Report_Transaction_Info.aspx.vb" Inherits="Report_Transaction_Info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Locker : Transaction Information </title>

  <meta charset="utf-8" />
  <meta name="description" content="" />
  <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1, maximum-scale=1" />
  <!-- build:css({.tmp,app}) styles/app.min.css -->
  <link rel="stylesheet" href="styles/webfont.css" />
  <link rel="stylesheet" href="styles/climacons-font.css" />
  <link rel="stylesheet" href="vendor/bootstrap/dist/css/bootstrap.css" />
  <link rel="stylesheet" href="styles/font-awesome.css" />
  <link rel="stylesheet" href="styles/card.css" />
  <link rel="stylesheet" href="styles/sli.css" />
  <link rel="stylesheet" href="styles/animate.css" />
  <link rel="stylesheet" href="styles/app.css" />
  <link rel="stylesheet" href="styles/app.skins.css" />
  <!-- endbuild -->

  <!-- Custom Style -->
    <style type="text/css">
        table
        {
            font-size:small;
            }

        .ErrorLog td {
        background-color:lightcoral;
        }

        .SuccessLog td {
        background-color:forestgreen;
        color:white;
        }
    </style>
  <!-- end costom style -->

</head>
<body>
    <form id="form1" runat="server">
<asp:ScriptManager ID="scm" runat="server"></asp:ScriptManager>
<div class="card card-block no-border bg-white row-equal align-middle">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
           <ContentTemplate>
                <div class="row table-responsive">  
                    <table class="table m-b no-more-tables">
                        <thead>
                          <tr>
                            <th colspan="2" class="h5 text-left">Transaction Info</th>
                            <th colspan="2" >
                                <asp:Label ID="lblStatus" runat="server" CssClass="pull-right h3"></asp:Label>                                
                            </th>                   
                          </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Deposit Transaction :</td>
                                <td class="h5"><asp:Label ID="lblTransactionNo" runat="server"></asp:Label></td> 
                                <td>Locker :</td> 
                                <td class="h5"><asp:Label ID="lblLockerName" runat="server"></asp:Label></td>
                                <td rowspan="4">
                                    <asp:Image ID="imgCusImage" runat="server"  Width="180px" Height="135px" BorderWidth="1" />
                                </td>                 
                            </tr>
                            <tr>
                                <td>Location :</td>
                                <td class="h5"><asp:Label ID="lblLocation" runat="server"></asp:Label></td>                    
                                <td>Kiosk :</td>
                                <td class="h5"><asp:Label ID="lblKioskName" runat="server"></asp:Label></td>
                            </tr>
                            
                            <tr>
                                <td>Deposit Start Time :</td>
                                <td class="h5"><asp:Label ID="lblDepositStartTime" runat="server"></asp:Label></td>                    
                                <td>Deposit Paid Time :</td>
                                <td class="h5"><asp:Label ID="lblDepositPaidTime" runat="server"></asp:Label></td>                    
                            </tr>
                            <tr><th colspan="4">&nbsp;</th></tr>
                            <tr>
                                <td>Collect Transaction :</td>
                                <td class="h5"><asp:Label ID="lblCollectTransNo" runat="server"></asp:Label></td> 
                                <td>Collect Time :</td> 
                                <td class="h5"><asp:Label ID="lblCollectTime" runat="server"></asp:Label></td>
                                <td rowspan="4">
                                    <asp:Image ID="imgCollectCustImage" runat="server"  Width="180px" Height="135px" BorderWidth="1" />
                                </td>              
                            </tr>  
                            <tr>
                                <td>Lost QR Code :</td>
                                <td class="h5"><asp:Label ID="lblLostQRCode" runat="server"></asp:Label></td> 
                                <td>Paid Time :</td> 
                                <td class="h5"><asp:Label ID="lblCollectPaidTime" runat="server"></asp:Label></td>                  
                            </tr>
                            <tr>
                                <td>Service Amount :</td>
                                <td class="h5"><asp:Label ID="lblServiceAmt" runat="server"></asp:Label></td> 
                                <td>Service Time :</td> 
                                <td class="h5"><asp:Label ID="lblServiceTime" runat="server"></asp:Label></td>                  
                            </tr>
                            <tr><th colspan="4">&nbsp;</th></tr>           
                      </tbody>
                    </table>  
                </div>

                <div class="row table-responsive">
                    <table class="table m-b no-more-tables">
                         <thead>
                              <tr>
                                <th colspan="2" class="h5 text-left">DEPOSIT ACTIVITY</th>                   
                              </tr>
                              <tr>
                                <th style="width:20%">Time</th>
                                <th  >Detail</th>             
                              </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptDepositList" runat="server">
                                <ItemTemplate>
                                    <tr id="tr" runat="server">
                                        <td data-title="Time" ><asp:Label ID="lblTime" runat="server"></asp:Label></td>
                                        <td data-title="Detail" ><asp:Label ID="lblDetail" runat="server"></asp:Label></td>                  
                                    </tr>
                                </ItemTemplate>                          
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>

                <div class="row table-responsive">
                    <table class="table m-b no-more-tables">
                         <thead>
                              <tr>
                                <th class="h5 text-left">COLLECT ACTIVITY</th>                   
                              </tr>
                         </thead>
                    </table>
                         
                    <asp:Repeater ID="rptCollectHead" runat="server">
                        <ItemTemplate>
                            <table class="table m-b no-more-tables">
                                <thead>
                                    <tr>
                                        <th colspan="2" class="h5 text-left">COLLECT TRANSACTION <asp:Label ID="lblCollectTransNo" runat="server" ></asp:Label></th>                   
                                    </tr>
                                    <tr>
                                        <th style="width:20%">Time</th>
                                        <th  >Detail</th>             
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptCollectList" runat="server">
                                        <ItemTemplate>
                                            <tr id="tr" runat="server">
                                                <td data-title="Time" ><asp:Label ID="lblTime" runat="server"></asp:Label></td>
                                                <td data-title="Detail" ><asp:Label ID="lblDetail" runat="server"></asp:Label></td>                  
                                            </tr>
                                        </ItemTemplate>                          
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </ItemTemplate>                          
                    </asp:Repeater>
                </div>
           </ContentTemplate>
        </asp:UpdatePanel>  
   
                </div>
    </form>
</body>
</html>
