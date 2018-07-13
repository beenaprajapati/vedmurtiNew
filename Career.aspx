<%@ Page Title="Career" Language="C#" MasterPageFile="Main_Master.master" AutoEventWireup="true" CodeFile="Career.aspx.cs" Inherits="Career" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .career-info h3 {
            font-family: 'Open Sans', sans-serif;
            margin: 0 0 25px 0;
            font-size: 22px;
            text-align: center;
            color: #12a6f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="toolkitmngr" runat="server"></cc1:ToolkitScriptManager>
    <link href="css/career-form.css" rel="stylesheet" />

    <asp:PlaceHolder runat="server">
        <script type="text/javascript">
            var widgetId1;
            var onloadCallback = function () {
                widgetId1 = grecaptcha.render('reCaptch', {

                    // 'sitekey': '6Lfs0RIUAAAAAAvbFvr4Bh89EtrIEz-bilvnXGmQ'
                    sitekey: System.Configuration.ConfigurationManager.AppSettings["sitekey"]

                });
            };
        </script>

        <script src='https://www.google.com/recaptcha/api.js' type="text/javascript"></script>
    </asp:PlaceHolder>


    <div class="carrer-form">

        <div class="container">

            <div class="career-info" align="center">
                <br>
                <h3>Apply Now </h3>

            </div>

            <div class="row">
                <div class="col-sm-12 col-md-offset-2 col-md-8 col-lg-offset-3 col-lg-6 no-padding carrer-form-mob">
                    <div class="form-group">
                        <div class="col-sm-12 validationSummary">
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server"
                                ForeColor="Red" ValidationGroup="a" Font-Size="Medium" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-3 col-md-3 col-lg-4">
                            <label class="control-label" for="email">
                                Full Name : 
                                 <span class="required">
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                         ErrorMessage="Enter First name" ControlToValidate="S_name" ForeColor="Red"
                                         ValidationGroup="a">*</asp:RequiredFieldValidator>
                                 </span>

                                <span class="required">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ErrorMessage="Enter Last name" ControlToValidate="S_lname" ForeColor="Red"
                                        ValidationGroup="a">*</asp:RequiredFieldValidator></span>
                                <span class="required"></span>

                            </label>

                        </div>
                        <div class="col-sm-9 col-md-9 col-lg-8">
                            <div class="input-part">
                                <div class="mr">
                                    <asp:DropDownList ID="mrs" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="Mr." Selected="True">Mr. </asp:ListItem>
                                        <asp:ListItem Value="Ms.">Ms. </asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="first-name">
                                    <asp:TextBox ID="S_name" runat="server" CssClass="form-control" placeholder="First Name"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="S_name"
                                        ErrorMessage="Enter Valid First Name" ValidationExpression="^[a-zA-Z'.\s]{1,50}" ForeColor="Red" ValidationGroup="a"></asp:RegularExpressionValidator>
                                </div>
                                <div class="last-name">
                                    <asp:TextBox ID="S_lname" runat="server" CssClass="form-control" placeholder="Last Name"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="S_lname"
                                        ErrorMessage="Enter Valid Last Name" ValidationExpression="^[a-zA-Z'.\s]{1,50}" ForeColor="Red" ValidationGroup="a"></asp:RegularExpressionValidator>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-3 col-md-3 col-lg-4">
                            <label class="control-label" for="pwd">
                                Date of Birth: 
                                <span class="required">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                        ErrorMessage="Select Date" ControlToValidate="dateddl" ForeColor="Red"
                                        ValidationGroup="a" InitialValue="0">*</asp:RequiredFieldValidator>
                                </span>
                                <span class="required">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                        ErrorMessage="Select Month" ControlToValidate="month" ForeColor="Red"
                                        ValidationGroup="a" InitialValue="0">*</asp:RequiredFieldValidator>
                                </span>
                                <span class="required">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                        ErrorMessage="Select Year" ControlToValidate="year" ForeColor="Red"
                                        ValidationGroup="a" InitialValue="0">*</asp:RequiredFieldValidator>
                                </span>
                            </label>



                        </div>
                        <div class="col-sm-9 col-md-9 col-lg-8">
                            <div class="input-part">
                                <div class="date">
                                    <asp:DropDownList class="form-control" ID="dateddl" runat="server">
                                        <asp:ListItem Value="0" Selected="True">Date</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                        <asp:ListItem>13</asp:ListItem>
                                        <asp:ListItem>14</asp:ListItem>
                                        <asp:ListItem>15</asp:ListItem>
                                        <asp:ListItem>16</asp:ListItem>
                                        <asp:ListItem>17</asp:ListItem>
                                        <asp:ListItem>18</asp:ListItem>
                                        <asp:ListItem>19</asp:ListItem>
                                        <asp:ListItem>20</asp:ListItem>
                                        <asp:ListItem>21</asp:ListItem>
                                        <asp:ListItem>22</asp:ListItem>
                                        <asp:ListItem>23</asp:ListItem>
                                        <asp:ListItem>24</asp:ListItem>
                                        <asp:ListItem>25</asp:ListItem>
                                        <asp:ListItem>26</asp:ListItem>
                                        <asp:ListItem>27</asp:ListItem>
                                        <asp:ListItem>28</asp:ListItem>
                                        <asp:ListItem>29</asp:ListItem>
                                        <asp:ListItem>30</asp:ListItem>
                                        <asp:ListItem>31</asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                                <div class="date">
                                    <asp:DropDownList ID="month" runat="server" class="form-control">
                                        <asp:ListItem Value="0" Selected="True">Month</asp:ListItem>
                                        <asp:ListItem>January</asp:ListItem>
                                        <asp:ListItem>February</asp:ListItem>
                                        <asp:ListItem>March</asp:ListItem>
                                        <asp:ListItem>April</asp:ListItem>
                                        <asp:ListItem>May</asp:ListItem>
                                        <asp:ListItem>June</asp:ListItem>
                                        <asp:ListItem>July</asp:ListItem>
                                        <asp:ListItem>August</asp:ListItem>
                                        <asp:ListItem>September</asp:ListItem>
                                        <asp:ListItem>October</asp:ListItem>
                                        <asp:ListItem>November</asp:ListItem>
                                        <asp:ListItem>December</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="date" style="margin: 0px;">
                                    <asp:DropDownList ID="year" class="form-control" runat="server">

                                        <asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
                                        <asp:ListItem>1990</asp:ListItem>
                                        <asp:ListItem>1989</asp:ListItem>
                                        <asp:ListItem>1988</asp:ListItem>
                                        <asp:ListItem>1987</asp:ListItem>
                                        <asp:ListItem>1986</asp:ListItem>
                                        <asp:ListItem>1985</asp:ListItem>
                                        <asp:ListItem>1984</asp:ListItem>
                                        <asp:ListItem>1983</asp:ListItem>
                                        <asp:ListItem>1982</asp:ListItem>
                                        <asp:ListItem>1981</asp:ListItem>
                                        <asp:ListItem>1980</asp:ListItem>
                                        <asp:ListItem>1979</asp:ListItem>
                                        <asp:ListItem>1978</asp:ListItem>
                                        <asp:ListItem>1977</asp:ListItem>
                                        <asp:ListItem>1976</asp:ListItem>
                                        <asp:ListItem>1975</asp:ListItem>
                                        <asp:ListItem>1974</asp:ListItem>
                                        <asp:ListItem>1973</asp:ListItem>
                                        <asp:ListItem>1972</asp:ListItem>
                                        <asp:ListItem>1971</asp:ListItem>
                                        <asp:ListItem>1970</asp:ListItem>
                                        <asp:ListItem>1969</asp:ListItem>
                                        <asp:ListItem>1968</asp:ListItem>
                                        <asp:ListItem>1967</asp:ListItem>
                                        <asp:ListItem>1966</asp:ListItem>
                                        <asp:ListItem>1965</asp:ListItem>
                                        <asp:ListItem>1964</asp:ListItem>
                                        <asp:ListItem>1963</asp:ListItem>
                                        <asp:ListItem>1962</asp:ListItem>
                                        <asp:ListItem>1961</asp:ListItem>
                                        <asp:ListItem>1960</asp:ListItem>
                                        <asp:ListItem>1959</asp:ListItem>
                                        <asp:ListItem>1958</asp:ListItem>
                                        <asp:ListItem>1957</asp:ListItem>
                                        <asp:ListItem>1956</asp:ListItem>
                                        <asp:ListItem>1955</asp:ListItem>
                                        <asp:ListItem>1954</asp:ListItem>
                                        <asp:ListItem>1953</asp:ListItem>
                                        <asp:ListItem>1952</asp:ListItem>
                                        <asp:ListItem>1951</asp:ListItem>
                                        <asp:ListItem>1950</asp:ListItem>
                                        <asp:ListItem>1949</asp:ListItem>
                                        <asp:ListItem>1948</asp:ListItem>
                                        <asp:ListItem>1947</asp:ListItem>
                                        <asp:ListItem>1946</asp:ListItem>
                                        <asp:ListItem>1945</asp:ListItem>
                                        <asp:ListItem>1944</asp:ListItem>
                                        <asp:ListItem>1943</asp:ListItem>
                                        <asp:ListItem>1942</asp:ListItem>
                                        <asp:ListItem>1941</asp:ListItem>
                                        <asp:ListItem>1940</asp:ListItem>
                                        <asp:ListItem>1939</asp:ListItem>
                                        <asp:ListItem>1938</asp:ListItem>
                                        <asp:ListItem>1937</asp:ListItem>
                                        <asp:ListItem>1936</asp:ListItem>
                                        <asp:ListItem>1935</asp:ListItem>
                                        <asp:ListItem>1934</asp:ListItem>
                                        <asp:ListItem>1933</asp:ListItem>
                                        <asp:ListItem>1932</asp:ListItem>
                                        <asp:ListItem>1931</asp:ListItem>
                                        <asp:ListItem>1930</asp:ListItem>
                                        <asp:ListItem>1929</asp:ListItem>
                                        <asp:ListItem>1928</asp:ListItem>
                                        <asp:ListItem>1927</asp:ListItem>
                                        <asp:ListItem>1926</asp:ListItem>
                                        <asp:ListItem>1925</asp:ListItem>
                                        <asp:ListItem>1924</asp:ListItem>
                                        <asp:ListItem>1923</asp:ListItem>
                                        <asp:ListItem>1922</asp:ListItem>
                                        <asp:ListItem>1921</asp:ListItem>
                                        <asp:ListItem>1920</asp:ListItem>
                                    </asp:DropDownList>

                                </div>

                            </div>

                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-3 col-md-3 col-lg-4">
                            <label class="control-label" for="pwd">
                                Email: <span class="required">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                        ErrorMessage="Enter Email" ControlToValidate="S_email" ForeColor="Red"
                                        ValidationGroup="a">*</asp:RequiredFieldValidator></span>



                            </label>


                        </div>
                        <div class="col-sm-9 col-md-9 col-lg-8">
                            <asp:TextBox ID="S_email" CssClass="form-control" runat="server" placeholder="Enter your email"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RequiredFieldValidatoras" ControlToValidate="S_email"
                                ErrorMessage="Enter Valid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" ValidationGroup="a"
                                runat="server"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-3 col-md-3 col-lg-4">
                            <label class="control-label" for="pwd">
                                Country: <span class="required">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                        ErrorMessage="Select Country" ControlToValidate="country" ForeColor="Red" InitialValue="0"
                                        ValidationGroup="a">*</asp:RequiredFieldValidator></span>
                            </label>


                        </div>
                        <div class="col-sm-9 col-md-9 col-lg-8">
                            <asp:DropDownList class="form-control" ID="country" runat="server">
                                <asp:ListItem Value="0">---Choose One---</asp:ListItem>
                                <asp:ListItem Value="AU">Australia</asp:ListItem>
                                <asp:ListItem Value="AT">Austria</asp:ListItem>
                                <asp:ListItem Value="BE">Belgium</asp:ListItem>
                                <asp:ListItem Value="CA">Canada</asp:ListItem>
                                <asp:ListItem Value="DK">Denmark</asp:ListItem>
                                <asp:ListItem Value="CZ">Czech Republic</asp:ListItem>
                                <asp:ListItem Value="DE">Germany</asp:ListItem>
                                <asp:ListItem Value="FR">France</asp:ListItem>
                                <asp:ListItem Value="MX">Mexico</asp:ListItem>
                                <asp:ListItem Value="NZ">New Zealand</asp:ListItem>
                                <asp:ListItem Value="NO">Norway</asp:ListItem>
                                <asp:ListItem Value="ES">Spain</asp:ListItem>
                                <asp:ListItem Value="CH">Switzerland</asp:ListItem>
                                <asp:ListItem Value="UK">United Kingdom</asp:ListItem>
                                <asp:ListItem Value="US">United States of America</asp:ListItem>

                                <asp:ListItem Value="AF">Afghanistan</asp:ListItem>
                                <asp:ListItem Value="AL">Albania</asp:ListItem>
                                <asp:ListItem Value="DZ">Algeria</asp:ListItem>
                                <asp:ListItem Value="AS">American Samoa</asp:ListItem>
                                <asp:ListItem Value="AD">Andorra</asp:ListItem>
                                <asp:ListItem Value="AO">Angola</asp:ListItem>
                                <asp:ListItem Value="AI">Anguilla</asp:ListItem>
                                <asp:ListItem Value="AQ">Antarctica</asp:ListItem>
                                <asp:ListItem Value="AG">Antigua And Barbuda</asp:ListItem>
                                <asp:ListItem Value="AR">Argentina</asp:ListItem>
                                <asp:ListItem Value="AM">Armenia</asp:ListItem>
                                <asp:ListItem Value="AW">Aruba</asp:ListItem>
                                <asp:ListItem Value="AU">Australia</asp:ListItem>
                                <asp:ListItem Value="AT">Austria</asp:ListItem>
                                <asp:ListItem Value="AZ">Azerbaijan</asp:ListItem>
                                <asp:ListItem Value="BS">Bahamas, The</asp:ListItem>
                                <asp:ListItem Value="BH">Bahrain</asp:ListItem>
                                <asp:ListItem Value="BD">Bangladesh</asp:ListItem>
                                <asp:ListItem Value="BB">Barbados</asp:ListItem>
                                <asp:ListItem Value="BY">Belarus</asp:ListItem>
                                <asp:ListItem Value="BE">Belgium</asp:ListItem>
                                <asp:ListItem Value="BZ">Belize</asp:ListItem>
                                <asp:ListItem Value="BJ">Benin</asp:ListItem>
                                <asp:ListItem Value="BM">Bermuda</asp:ListItem>
                                <asp:ListItem Value="BT">Bhutan</asp:ListItem>
                                <asp:ListItem Value="BO">Bolivia</asp:ListItem>
                                <asp:ListItem Value="BA">Bosnia and Herzegovina</asp:ListItem>
                                <asp:ListItem Value="BW">Botswana</asp:ListItem>
                                <asp:ListItem Value="BV">Bouvet Island</asp:ListItem>
                                <asp:ListItem Value="br">Brazil</asp:ListItem>
                                <asp:ListItem Value="IO">British Indian Ocean Territory</asp:ListItem>
                                <asp:ListItem Value="BN">Brunei</asp:ListItem>
                                <asp:ListItem Value="BG">Bulgaria</asp:ListItem>
                                <asp:ListItem Value="BF">Burkina Faso</asp:ListItem>
                                <asp:ListItem Value="BI">Burundi</asp:ListItem>
                                <asp:ListItem Value="KH">Cambodia</asp:ListItem>
                                <asp:ListItem Value="CM">Cameroon</asp:ListItem>
                                <asp:ListItem Value="CA">Canada</asp:ListItem>
                                <asp:ListItem Value="CV">Cape Verde</asp:ListItem>
                                <asp:ListItem Value="KY">Cayman Islands</asp:ListItem>
                                <asp:ListItem Value="CF">Central African Republic</asp:ListItem>
                                <asp:ListItem Value="td">Chad</asp:ListItem>
                                <asp:ListItem Value="CL">Chile</asp:ListItem>
                                <asp:ListItem Value="CN">China</asp:ListItem>
                                <asp:ListItem Value="HK">China (Hong Kong S.A.R.)</asp:ListItem>
                                <asp:ListItem Value="MO">China (Macau S.A.R.)</asp:ListItem>
                                <asp:ListItem Value="CX">Christmas</asp:ListItem>
                                <asp:ListItem Value="CC">Cocos (Keeling) Islands</asp:ListItem>
                                <asp:ListItem Value="CO">Colombia</asp:ListItem>
                                <asp:ListItem Value="KM">Comoros</asp:ListItem>
                                <asp:ListItem Value="CG">Congo</asp:ListItem>
                                <asp:ListItem Value="CD">Congo, Democractic Republic of</asp:ListItem>
                                <asp:ListItem Value="CK">Cook Islands</asp:ListItem>
                                <asp:ListItem Value="CR">Costa Rica</asp:ListItem>
                                <asp:ListItem Value="CI">Cote D'Ivoire (Ivory Coast)</asp:ListItem>
                                <asp:ListItem Value="HR">Croatia (Hrvatska)</asp:ListItem>
                                <asp:ListItem Value="CU">Cuba</asp:ListItem>
                                <asp:ListItem Value="CY">Cyprus</asp:ListItem>
                                <asp:ListItem Value="CZ">Czech Republic</asp:ListItem>
                                <asp:ListItem Value="DK">Denmark</asp:ListItem>
                                <asp:ListItem Value="DJ">Djibouti</asp:ListItem>
                                <asp:ListItem Value="DM">Dominica</asp:ListItem>
                                <asp:ListItem Value="DO">Dominican Republic</asp:ListItem>
                                <asp:ListItem Value="TP">East Timor</asp:ListItem>
                                <asp:ListItem Value="EC">Ecuador</asp:ListItem>
                                <asp:ListItem Value="EG">Egypt</asp:ListItem>
                                <asp:ListItem Value="SV">El Salvador</asp:ListItem>
                                <asp:ListItem Value="GQ">Equatorial Guinea</asp:ListItem>
                                <asp:ListItem Value="ER">Eritrea</asp:ListItem>
                                <asp:ListItem Value="EE">Estonia</asp:ListItem>
                                <asp:ListItem Value="ET">Ethiopia</asp:ListItem>
                                <asp:ListItem Value="FK">Falkland Islands (Islas Malvin)</asp:ListItem>
                                <asp:ListItem Value="FO">Faroe Islands</asp:ListItem>
                                <asp:ListItem Value="FJ">Fiji Islands</asp:ListItem>
                                <asp:ListItem Value="FI">Finland</asp:ListItem>
                                <asp:ListItem Value="FR">France</asp:ListItem>
                                <asp:ListItem Value="GF">French Guiana</asp:ListItem>
                                <asp:ListItem Value="PF">French Polynesia</asp:ListItem>
                                <asp:ListItem Value="TF">French Southern Territories</asp:ListItem>
                                <asp:ListItem Value="GA">Gabon</asp:ListItem>
                                <asp:ListItem Value="GM">Gambia, The</asp:ListItem>
                                <asp:ListItem Value="GE">Georgia</asp:ListItem>
                                <asp:ListItem Value="DE">Germany</asp:ListItem>
                                <asp:ListItem Value="GH">Ghana</asp:ListItem>
                                <asp:ListItem Value="GI">Gibraltar</asp:ListItem>
                                <asp:ListItem Value="GR">Greece</asp:ListItem>
                                <asp:ListItem Value="GL">Greenland</asp:ListItem>
                                <asp:ListItem Value="GD">Grenada</asp:ListItem>
                                <asp:ListItem Value="GP">Guadeloupe</asp:ListItem>
                                <asp:ListItem Value="GU">Guam</asp:ListItem>
                                <asp:ListItem Value="GT">Guatemala</asp:ListItem>
                                <asp:ListItem Value="GN">Guinea</asp:ListItem>
                                <asp:ListItem Value="GW">Guinea-Bissau</asp:ListItem>
                                <asp:ListItem Value="GY">Guyana</asp:ListItem>
                                <asp:ListItem Value="HT">Haiti</asp:ListItem>
                                <asp:ListItem Value="HM">Heard and McDonald Islands</asp:ListItem>
                                <asp:ListItem Value="HN">Honduras</asp:ListItem>
                                <asp:ListItem Value="HU">Hungary</asp:ListItem>
                                <asp:ListItem Value="IS">Iceland</asp:ListItem>
                                <asp:ListItem Value="IN">India</asp:ListItem>
                                <asp:ListItem Value="ID">Indonesia</asp:ListItem>
                                <asp:ListItem Value="IR">Iran</asp:ListItem>
                                <asp:ListItem Value="IQ">Iraq</asp:ListItem>
                                <asp:ListItem Value="IE">Ireland</asp:ListItem>
                                <asp:ListItem Value="IL">Israel</asp:ListItem>
                                <asp:ListItem Value="IT">Italy</asp:ListItem>
                                <asp:ListItem Value="JM">Jamaica</asp:ListItem>
                                <asp:ListItem Value="JP">Japan</asp:ListItem>
                                <asp:ListItem Value="JO">Jordan</asp:ListItem>
                                <asp:ListItem Value="KZ">Kazakhstan</asp:ListItem>
                                <asp:ListItem Value="KE">Kenya</asp:ListItem>
                                <asp:ListItem Value="KI">Kiribati</asp:ListItem>
                                <asp:ListItem Value="KR">Korea</asp:ListItem>
                                <asp:ListItem Value="KP">Korea, North</asp:ListItem>
                                <asp:ListItem Value="KW">Kuwait</asp:ListItem>
                                <asp:ListItem Value="KG">Kyrgyzstan</asp:ListItem>
                                <asp:ListItem Value="LA">Laos PDR</asp:ListItem>
                                <asp:ListItem Value="LV">Latvia</asp:ListItem>
                                <asp:ListItem Value="LB">Lebanon</asp:ListItem>
                                <asp:ListItem Value="LS">Lesotho</asp:ListItem>
                                <asp:ListItem Value="LR">Liberia</asp:ListItem>
                                <asp:ListItem Value="LY">Libya</asp:ListItem>
                                <asp:ListItem Value="LI">Liechtenstein</asp:ListItem>
                                <asp:ListItem Value="LT">Lithuania</asp:ListItem>
                                <asp:ListItem Value="LU">Luxembourg</asp:ListItem>
                                <asp:ListItem Value="MK">Macedonia</asp:ListItem>
                                <asp:ListItem Value="MG">Madagascar</asp:ListItem>
                                <asp:ListItem Value="MW">Malawi</asp:ListItem>
                                <asp:ListItem Value="MY">Malaysia</asp:ListItem>
                                <asp:ListItem Value="MV">Maldives</asp:ListItem>
                                <asp:ListItem Value="ML">Mali</asp:ListItem>
                                <asp:ListItem Value="MT">Malta</asp:ListItem>
                                <asp:ListItem Value="MH">Marshall Islands</asp:ListItem>
                                <asp:ListItem Value="MQ">Martinique</asp:ListItem>
                                <asp:ListItem Value="MR">Mauritania</asp:ListItem>
                                <asp:ListItem Value="MU">Mauritius</asp:ListItem>
                                <asp:ListItem Value="YT">Mayotte</asp:ListItem>
                                <asp:ListItem Value="MX">Mexico</asp:ListItem>
                                <asp:ListItem Value="FM">Micronesia</asp:ListItem>
                                <asp:ListItem Value="MD">Moldova</asp:ListItem>
                                <asp:ListItem Value="MC">Monaco</asp:ListItem>
                                <asp:ListItem Value="MN">Mongolia</asp:ListItem>
                                <asp:ListItem Value="ME">Montenegro</asp:ListItem>
                                <asp:ListItem Value="MS">Montserrat</asp:ListItem>
                                <asp:ListItem Value="MA">Morocco</asp:ListItem>
                                <asp:ListItem Value="MZ">Mozambique</asp:ListItem>
                                <asp:ListItem Value="MM">Myanmar</asp:ListItem>
                                <asp:ListItem Value="NA">Namibia</asp:ListItem>
                                <asp:ListItem Value="NR">Nauru</asp:ListItem>
                                <asp:ListItem Value="NP">Nepal</asp:ListItem>
                                <asp:ListItem Value="AN">Netherlands Antilles</asp:ListItem>
                                <asp:ListItem Value="NC">New Caledonia</asp:ListItem>
                                <asp:ListItem Value="NZ">New Zealand</asp:ListItem>
                                <asp:ListItem Value="NI">Nicaragua</asp:ListItem>
                                <asp:ListItem Value="NE">Niger</asp:ListItem>
                                <asp:ListItem Value="NG">Nigeria</asp:ListItem>
                                <asp:ListItem Value="NU">Niue</asp:ListItem>
                                <asp:ListItem Value="NF">Norfolk Island</asp:ListItem>
                                <asp:ListItem Value="MP">Northern Mariana Islands</asp:ListItem>
                                <asp:ListItem Value="NO">Norway</asp:ListItem>
                                <asp:ListItem Value="OM">Oman</asp:ListItem>
                                <asp:ListItem Value="PK">Pakistan</asp:ListItem>
                                <asp:ListItem Value="PW">Palau</asp:ListItem>
                                <asp:ListItem Value="PA">Panama</asp:ListItem>
                                <asp:ListItem Value="PG">Papua new Guinea</asp:ListItem>
                                <asp:ListItem Value="PY">Paraguay</asp:ListItem>
                                <asp:ListItem Value="PE">Peru</asp:ListItem>
                                <asp:ListItem Value="PH">Philippines</asp:ListItem>
                                <asp:ListItem Value="PN">Pitcairn Island</asp:ListItem>
                                <asp:ListItem Value="PL">Poland</asp:ListItem>
                                <asp:ListItem Value="PT">Portugal</asp:ListItem>
                                <asp:ListItem Value="PR">Puerto Rico</asp:ListItem>
                                <asp:ListItem Value="QA">Qatar</asp:ListItem>
                                <asp:ListItem Value="RE">Reunion</asp:ListItem>
                                <asp:ListItem Value="RO">Romania</asp:ListItem>
                                <asp:ListItem Value="RU">Russia</asp:ListItem>
                                <asp:ListItem Value="RW">Rwanda</asp:ListItem>
                                <asp:ListItem Value="SH">Saint Helena</asp:ListItem>
                                <asp:ListItem Value="KN">Saint Kitts And Nevis</asp:ListItem>
                                <asp:ListItem Value="LC">Saint Lucia</asp:ListItem>
                                <asp:ListItem Value="PM">Saint Pierre and Miquelon</asp:ListItem>
                                <asp:ListItem Value="VC">Saint Vincent And The Grenadin</asp:ListItem>
                                <asp:ListItem Value="WS">Samoa</asp:ListItem>
                                <asp:ListItem Value="SM">San Marino</asp:ListItem>
                                <asp:ListItem Value="ST">Sao Tome and Principe</asp:ListItem>
                                <asp:ListItem Value="SA">Saudi Arabia</asp:ListItem>
                                <asp:ListItem Value="SN">Senegal</asp:ListItem>
                                <asp:ListItem Value="RS">Serbia</asp:ListItem>
                                <asp:ListItem Value="SC">Seychelles</asp:ListItem>
                                <asp:ListItem Value="SL">Sierra Leone</asp:ListItem>
                                <asp:ListItem Value="SG">Singapore</asp:ListItem>
                                <asp:ListItem Value="SK">Slovakia</asp:ListItem>
                                <asp:ListItem Value="SI">Slovenia</asp:ListItem>
                                <asp:ListItem Value="SB">Solomon Islands</asp:ListItem>
                                <asp:ListItem Value="SO">Somalia</asp:ListItem>
                                <asp:ListItem Value="ZA">South Africa</asp:ListItem>
                                <asp:ListItem Value="GS">South Georgia</asp:ListItem>
                                <asp:ListItem Value="ES">Spain</asp:ListItem>
                                <asp:ListItem Value="LK">Sri Lanka</asp:ListItem>
                                <asp:ListItem Value="SD">Sudan</asp:ListItem>
                                <asp:ListItem Value="SR">Suriname</asp:ListItem>
                                <asp:ListItem Value="SJ">Svalbard And Jan Mayen Islands</asp:ListItem>
                                <asp:ListItem Value="SZ">Swaziland</asp:ListItem>
                                <asp:ListItem Value="SE">Sweden</asp:ListItem>
                                <asp:ListItem Value="CH">Switzerland</asp:ListItem>
                                <asp:ListItem Value="SY">Syria</asp:ListItem>
                                <asp:ListItem Value="TW">Taiwan</asp:ListItem>
                                <asp:ListItem Value="TJ">Tajikistan</asp:ListItem>
                                <asp:ListItem Value="TZ">Tanzania</asp:ListItem>
                                <asp:ListItem Value="TH">Thailand</asp:ListItem>
                                <asp:ListItem Value="NL">The Netherlands</asp:ListItem>
                                <asp:ListItem Value="TG">Togo</asp:ListItem>
                                <asp:ListItem Value="TK">Tokelau</asp:ListItem>
                                <asp:ListItem Value="TO">Tonga</asp:ListItem>
                                <asp:ListItem Value="TT">Trinidad And Tobago</asp:ListItem>
                                <asp:ListItem Value="TN">Tunisia</asp:ListItem>
                                <asp:ListItem Value="tr">Turkey</asp:ListItem>
                                <asp:ListItem Value="TM">Turkmenistan</asp:ListItem>
                                <asp:ListItem Value="TC">Turks And Caicos Islands</asp:ListItem>
                                <asp:ListItem Value="TV">Tuvalu</asp:ListItem>
                                <asp:ListItem Value="UG">Uganda</asp:ListItem>
                                <asp:ListItem Value="UA">Ukraine</asp:ListItem>
                                <asp:ListItem Value="AE">United Arab Emirates</asp:ListItem>
                                <asp:ListItem Value="UK">United Kingdom</asp:ListItem>
                                <asp:ListItem Value="UM">United States Minor Outlying I</asp:ListItem>
                                <asp:ListItem Value="US">United States of America</asp:ListItem>
                                <asp:ListItem Value="UY">Uruguay</asp:ListItem>
                                <asp:ListItem Value="UZ">Uzbekistan</asp:ListItem>
                                <asp:ListItem Value="VU">Vanuatu</asp:ListItem>
                                <asp:ListItem Value="VA">Vatican City State (Holy See)</asp:ListItem>
                                <asp:ListItem Value="VE">Venezuela</asp:ListItem>
                                <asp:ListItem Value="VN">Vietnam</asp:ListItem>
                                <asp:ListItem Value="VG">Virgin Islands (British)</asp:ListItem>
                                <asp:ListItem Value="VI">Virgin Islands (US)</asp:ListItem>
                                <asp:ListItem Value="WF">Wallis And Futuna Islands</asp:ListItem>
                                <asp:ListItem Value="EH">Western Sahara</asp:ListItem>
                                <asp:ListItem Value="YE">Yemen</asp:ListItem>
                                <asp:ListItem Value="YU">Yugoslavia</asp:ListItem>
                                <asp:ListItem Value="ZM">Zambia</asp:ListItem>
                                <asp:ListItem Value="ZW">Zimbabwe</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-3 col-md-3 col-lg-4">
                            <label class="control-label" for="email">
                                Phone: 
                            <span class="required">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                    ErrorMessage="Enter Phone Number" ControlToValidate="S_phone" ForeColor="Red"
                                    ValidationGroup="a">*</asp:RequiredFieldValidator>
                            </span>
                            </label>

                        </div>
                        <div class="col-sm-9 col-md-9 col-lg-8">
                            <div class="input-part">

                                <div>
                                    <asp:TextBox ID="S_phone" runat="server" CssClass="form-control" placeholder="Phone Number"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="S_phone" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="S_phone" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-3 col-md-3 col-lg-4">
                            <label class="control-label" for="email">
                                Mobile: 
                           <span class="required">
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                   ErrorMessage="Enter Mobile" ControlToValidate="S_mobile" ForeColor="Red"
                                   ValidationGroup="a">*</asp:RequiredFieldValidator>
                           </span>
                            </label>
                        </div>
                        <div class="col-sm-9 col-md-9 col-lg-8">
                            <div class="input-part">
                                <div>
                                    <asp:TextBox ID="S_mobile" runat="server" CssClass="form-control" placeholder="Mobile Number"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="f1" runat="server" TargetControlID="S_mobile" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="S_mobile" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+" ForeColor="Red" ValidationGroup="a"></asp:RegularExpressionValidator>

                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-3 col-md-3 col-lg-4">
                            <label class="control-label" for="pwd">
                                Current Employer:  <span class="required">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                        ErrorMessage="Enter Current Employer Name" ControlToValidate="employer" ForeColor="Red"
                                        ValidationGroup="a">*</asp:RequiredFieldValidator>
                                </span>
                            </label>





                        </div>
                        <div class="col-sm-9 col-md-9 col-lg-8">
                            <asp:TextBox runat="server" ID="employer" CssClass="form-control" placeholder="Current Employer"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-3 col-md-3 col-lg-4">
                            <label class="control-label" for="pwd">
                                Present Location: <span class="required">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                        ErrorMessage="Enter Present Location" ControlToValidate="present" ForeColor="Red"
                                        ValidationGroup="a">*</asp:RequiredFieldValidator>
                                </span>

                            </label>


                        </div>
                        <div class="col-sm-9 col-md-9 col-lg-8">
                            <asp:TextBox runat="server" CssClass="form-control" ID="present" placeholder="Enter your Present Location"></asp:TextBox>

                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-3 col-md-3 col-lg-4">
                            <label class="control-label" for="pwd">
                                Preferred Location:
                                <span class="required">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                        ErrorMessage="Enter Preferred Location " ControlToValidate="preferred" ForeColor="Red"
                                        ValidationGroup="a">*</asp:RequiredFieldValidator>
                                </span>
                            </label>

                        </div>

                        <div class="col-sm-9 col-md-9 col-lg-8">
                            <asp:TextBox runat="server" CssClass="form-control" ID="preferred" placeholder="Enter Your Preferred Location"></asp:TextBox>

                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-3 col-md-3 col-lg-4">
                            <label class="control-label" for="pwd">
                                Highest Education: 
                                <span class="required">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                        ErrorMessage="Enter Highest Education" ControlToValidate="highest" ForeColor="Red"
                                        ValidationGroup="a">*</asp:RequiredFieldValidator></span>
                            </label>

                        </div>
                        <div class="col-sm-9 col-md-9 col-lg-8">
                            <asp:TextBox runat="server" CssClass="form-control" ID="highest" placeholder="Enter your Highest Education"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-3 col-md-3 col-lg-4">
                            <label class="control-label" for="pwd">Experience in Years:  </label>
                        </div>
                        <div class="col-sm-9 col-md-9 col-lg-8">
                            <asp:DropDownList CssClass="form-control" ID="experience" runat="server">
                                <asp:ListItem>Fresher</asp:ListItem>
                                <asp:ListItem>6 Months - 2 Years</asp:ListItem>
                                <asp:ListItem>2-5 Years</asp:ListItem>
                                <asp:ListItem>5-10 Years</asp:ListItem>
                                <asp:ListItem>10 Years +</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-3 col-md-3 col-lg-4">
                            <label class="control-label" for="pwd">Attach your Resume: </label>
                        </div>
                        <div class="col-sm-9 col-md-9 col-lg-8">
                            <asp:FileUpload CssClass="form-control" ID="resume" runat="server" placeholder="Enter your Highest Education" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-3 col-md-3 col-lg-4">
                            <label class="control-label" for="pwd">Comments:</label>
                        </div>
                        <div class="col-sm-9 col-md-9 col-lg-8">

                            <asp:TextBox runat="server" Columns="49" Rows="5" CssClass="form-control" ID="comments" TextMode="MultiLine" placeholder="Comments"></asp:TextBox>
                            <div class="g-recaptcha" data-sitekey='<%=System.Configuration.ConfigurationManager.AppSettings["sitekey"] %>'>
                            </div>
                            <asp:Label ID="captchaid" runat="server" Style="color: red"></asp:Label>
                            <div class="form-group">
                                <asp:Button Text="Submit" ID="submit2" runat="server" OnClick="submit2_Click" ValidationGroup="a" CssClass="btn btn-default" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>














        </div>
    </div>


     <script src="Scripts/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.unobtrusive-ajax.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.validate.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.validate.unobtrusive.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#ContentPlaceHolder1_submit2").on("click", function () {

                var ReCaptch = grecaptcha.getResponse(widgetId1);

                if (ReCaptch != "") {

                    return true;
                }

                $('#<%=captchaid.ClientID %>').html('Please enter valid captcha');

                return false;

            });
        });

    </script>

   
</asp:Content>


