<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="EN" lang="EN" dir="ltr">
<head profile="http://gmpg.org/xfn/11">
    <title>
        <asp:ContentPlaceHolder ID="TitleContent" runat="server" />
    </title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta http-equiv="imagetoolbar" content="no" />
    <link rel="stylesheet" href="styles/layout.css" type="text/css" />
</head>
<body id="top">
    <div class="wrapper col1">
        <div id="head">
            <h1>
                <a href="#">Corporation</a></h1>
            <p>
                Free CSS Website Template</p>
            <div id="topnav">
                <ul>
                    <li>
                        <%: Html.ActionLink("Home", "Index", "Home")%></li>
                    <li>
                        <%: Html.ActionLink("About", "About", "Home")%></li>
                    <li><a class="active" href="full-width.html">Full Width</a></li>
                    <li><a href="#">DropDown</a>
                        <ul>
                            <li><a href="#">Link 1</a></li>
                            <li><a href="#">Link 2</a></li>
                            <li><a href="#">Link 3</a></li>
                        </ul>
                    </li>
                    <li class="last"><a href="#">A Long Link Text</a></li>
                </ul>
            </div>
            <div id="search">
                <form action="#" method="post">
                <fieldset>
                    <legend>Site Search</legend>
                    <input type="submit" name="go" id="go" value="GO" />
                    <input type="text" value="Search the site&hellip;" onfocus="this.value=(this.value=='Search the site&hellip;')? '' : this.value ;" />
                </fieldset>
                </form>
            </div>
        </div>
    </div>
    <div class="wrapper col2">
        <div id="breadcrumb">
            <ul>
                <li class="first">You Are Here</li>
                <li>&#187;</li>
                <li><a href="#">Home</a></li>
                <li>&#187;</li>
                <li><a href="#">Grand Parent</a></li>
                <li>&#187;</li>
                <li><a href="#">Parent</a></li>
                <li>&#187;</li>
                <li class="current"><a href="#">Child</a></li>
            </ul>
        </div>
    </div>
    <div class="wrapper col4">
        <div id="container">
            <h1>
                Headline 1 Colour and Size</h1>
            <h2>
                Headline 2 Colour and Size</h2>
            <h3>
                Headline 3 Colour and Size</h3>
            <h4>
                Headline 4 Colour and Size</h4>
            <h5>
                Headline 5 Colour and Size</h5>
            <h6>
                Headline 6 Colour and Size</h6>
            <p>
                This.</p>
            <p>
                You can .</p>
            <ul>
                <li>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</li>
            </ul>
            <p>
                Vestibulumaccumsan.</p>
            <ol>
                <li>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</li>.</li>
            </ol>
        </div>
    </div>
    <div class="wrapper col5">
        <div id="footer">
            <div id="contactform">
                <h2>
                    Why Not Contact Us Today !</h2>
                <form action="#" method="post">
                <fieldset>
                    <legend>Contact Form</legend>
                    <label for="fullname">
                        Name:
                        <input id="fullname" name="fullname" type="text" value="" />
                    </label>
                    <label for="emailaddress" class="margin">
                        Email:
                        <input id="emailaddress" name="emailaddress" type="text" value="" />
                    </label>
                    <label for="phone">
                        Telephone:
                        <input id="phone" name="phone" type="text" value="" />
                    </label>
                    <label for="subject" class="margin">
                        Subject:
                        <input id="subject" name="subject" type="text" value="" />
                    </label>
                    <label for="message">
                        Message:<br />
                        <textarea id="message" name="message" cols="40" rows="4"></textarea>
                    </label>
                    <p>
                        <input id="submitform" name="submitform" type="submit" value="Submit" />
                        &nbsp;
                        <input id="resetform" name="resetform" type="reset" value="Reset" />
                    </p>
                </fieldset>
                </form>
            </div>
            <!-- End Contact Form -->
            <div id="compdetails">
                <div id="officialdetails">
                    <h2>
                        Company Information !</h2>
                    <ul>
                        <li>Company Name Ltd</li>
                        <li>Registered in England &amp; Wales</li>
                        <li>Company No. xxxxxxx</li>
                        <li class="last">VAT No. xxxxxxxxx</li>
                    </ul>
                    <h2>
                        Stay in The Know !</h2>
                    <p>
                        <a href="#">Get Our E-Newsletter</a> | <a href="#">Grab The RSS Feed</a></p>
                </div>
                <div id="contactdetails">
                    <h2>
                        Our Contact Details !</h2>
                    <ul>
                        <li>Company Name</li>
                        <li>Street Name &amp; Number</li>
                        <li>Town</li>
                        <li>Postcode/Zip</li>
                        <li>Tel: xxxxx xxxxxxxxxx</li>
                        <li>Fax: xxxxx xxxxxxxxxx</li>
                        <li>Email: info@domain.com</li>
                        <li class="last">LinkedIn: <a href="#">Company Profile</a></li>
                    </ul>
                </div>
                <div class="clear">
                </div>
            </div>
            <!-- End Company Details -->
            <div id="copyright">
                <p class="fl_left">
                    Copyright &copy; 2011 - All Rights Reserved - <a href="#">Domain Name</a></p>
                <p class="fl_right">
                    Template by <a href="http://www.os-templates.com/" title="Free Website Templates">OS
                        Templates</a></p>
                <br class="clear" />
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
</body>
</html>
