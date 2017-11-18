<%@ Page Title="" Language="VB" MasterPageFile="~/Master/MasterPage.Master" AutoEventWireup="false" CodeFile="frmChangePassword.aspx.vb" Inherits="frmChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContainer" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="page-title">
        <div class="title">Change Password</div>
        <div class="sub-title"></div>
    </div>
   
    <asp:UpdatePanel ID="udpList" runat="server">
        <ContentTemplate>
            <div class="col-sm-12" >

                <div class="col-sm-2" >
                </div>
                <div class="col-sm-8" >

                    <div class="page-content" style="text-align:right;" >
                    
                        <%--<h3 class="header smaller lighter blue" style="text-align:left">Change Password</h3>--%>
                        <div class="form-group" style="padding-left:30px">
                            <label class="col-sm-3 control-label"></label>
                            <div class="col-sm-9">
                               <h3 class="header smaller lighter blue" style="text-align:left">Change Password</h3>
                            </div>
                        </div>
                   
                        <div class="form-group">
                            <div class="col-sm-12">
                                &nbsp;
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label">Current Password</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtCurrentPassword" runat="server" CssClass="form-control" MaxLength="50" TextMode="Password" Width="300px"></asp:TextBox>
                              
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label">New Password</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" MaxLength="50" TextMode="Password" Width="300px"></asp:TextBox>
                               

                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label">Confirm Password</label>
                            <div class="col-sm-9">
                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" MaxLength="50" TextMode="Password" Width="300px"></asp:TextBox>
                              

                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-12">
                                &nbsp;
                            </div>
                        </div>



                         <div class="form-group" style="text-align:left ; padding-left:30px">
                            <label class="col-sm-3 control-label"></label>
                            <div class="col-sm-9">
                               
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

                         <div class="form-group" style="text-align: center">
                           
                        </div>



                    </div>

                    



                    <div class="form-group">
                        <label class="col-sm-3 control-label"></label>
                    </div>





                </div>
                <div class="col-sm-2" >
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContainer" Runat="Server">
</asp:Content>

