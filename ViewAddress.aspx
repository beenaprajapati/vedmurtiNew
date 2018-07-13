<%@ Page Title="" Language="C#" MasterPageFile="~/Main_Master.master" AutoEventWireup="true" CodeFile="ViewAddress.aspx.cs" Inherits="ViewAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .grid_4 th{
            text-align:center;
        }
         .itemstyle{
            	border: 1px solid #ddd;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="moments">
        <div class="container">
            <div class="row">
                   <a href="AddAddress.aspx" class="btn btn-details">
                            	<i class="fa fa-plus"></i>
                            	Add Address</a>
                <br />
                 <br />
                <asp:Label ID="lblid" runat="server"></asp:Label>
                 <div class="order-div">
                <asp:GridView ID="gridaddress" runat="server" AllowPaging="true"  EmptyDataText="No Record Found" PageSize="10" AutoGenerateColumns="false" Width="100%" CssClass="gridorder" OnPageIndexChanging="gridaddress_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Sr. No" ItemStyle-CssClass="itemstyle">
                        <ItemTemplate>
                           <%#Container.DataItemIndex+1 %>
                            <asp:HiddenField ID="hdnid" runat="server" Value='<%#Eval("AddressID") %>' />
                         </ItemTemplate>
                           <ItemStyle  HorizontalAlign="Center"/>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name" ItemStyle-CssClass="itemstyle">
                        <ItemTemplate>
                           <%#Eval("Name") %>
                        </ItemTemplate>
                         <ItemStyle  HorizontalAlign="Center"/>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email" ItemStyle-CssClass="itemstyle">
                        <ItemTemplate>
                             <%#Eval("EmailAddress") %>
                        </ItemTemplate>
                        <ItemStyle  HorizontalAlign="Center"/>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phone" ItemStyle-CssClass="itemstyle">
                        <ItemTemplate>
                          <%#Eval("PhoneNumber") %>
                        </ItemTemplate>
                        <ItemStyle  HorizontalAlign="Center"/>
                    </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="StateName" ItemStyle-CssClass="itemstyle">
                        <ItemTemplate>
                            <%#Eval("state") %>
                        </ItemTemplate>
                        <ItemStyle  HorizontalAlign="Center"/>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="City" ItemStyle-CssClass="itemstyle">
                        <ItemTemplate>
                            <%#Eval("City") %>
                        </ItemTemplate>
                        <ItemStyle  HorizontalAlign="Center"/>
                    </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderText="Address1">
                        <ItemTemplate>
                            <%#Eval("Address1") %>
                        </ItemTemplate>
                        <ItemStyle  HorizontalAlign="Center"/>
                    </asp:TemplateField>--%>
                   
                    <asp:TemplateField HeaderText="Action" ItemStyle-CssClass="itemstyle">
                        <ItemTemplate>
                            <a href='<%#"AddAddress.aspx?AddressId="+Eval("AddressID") %>'><img src="sw-login/images/pencil.gif" alt="" style="border:0;" /></a>
                            <%--<asp:LinkButton ID="btndelete" runat="server"  OnClick="btndelete" ><img src="images/delete.png" alt="" style="border:0;" /></asp:LinkButton>  |       --%>
                        </ItemTemplate>
                        <ItemStyle  HorizontalAlign="Center"/>
                    </asp:TemplateField>
                  
                </Columns>
                    
            </asp:GridView>
                     </div>
                </div>
            </div>
          </div>
</asp:Content>

