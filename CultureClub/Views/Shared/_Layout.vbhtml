<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - Social & culture Club</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
    <style type="text/css">
        table.table {
            table-layout: fixed;
        }

        .table td {
            white-space: normal !important;
            word-wrap: break-word;
        }

        dl.dl-horizontal {
            table-layout: fixed;
        }


        .dl-horizontal dd {
            white-space: normal !important;
            word-wrap: break-word;
        }



        .navbar-default {
            background-color: #f4f4f4;
            margin-top: 50px;
            border-width: 0;
            z-index: 5;
        }

            .navbar-default .navbar-nav > .active > a, .navbar-default .navbar-nav > li:hover > a {
                border: 0 solid #4285f4;
                border-bottom-width: 2px;
                font-weight: 800;
                background-color: transparent;
            }

            .navbar-default .dropdown-menu {
                background-color: #ffffff;
            }

                .navbar-default .dropdown-menu li > a {
                    padding-left: 30px;
                }

        .header {
            background-color: #ffffff;
            border-width: 0;
        }

            .header .navbar-collapse {
                background-color: #ffffff;
            }

        .btn, .form-control, .panel, .list-group, .well {
            border-radius: 1px;
            box-shadow: 0 0 0;
        }

        .form-control {
            border-color: #d7d7d7;
        }

        .btn-primary {
            border-color: transparent;
        }

        .btn-primary, .label-primary, .list-group-item.active, .list-group-item.active:hover, .list-group-item.active:focus {
            background-color: #4285f4;
        }

        .btn-plus {
            background-color: #ffffff;
            border-width: 1px;
            border-color: #dddddd;
            box-shadow: 1px 1px 0 #999999;
            border-radius: 3px;
            color: #666666;
            text-shadow: 0 0 1px #bbbbbb;
        }

        .well, .panel {
            border-color: #d2d2d2;
            box-shadow: 0 1px 0 #cfcfcf;
            border-radius: 3px;
        }

        .btn-success, .label-success, .progress-bar-success {
            background-color: #65b045;
        }

        .btn-info, .label-info, .progress-bar-info {
            background-color: #a0c3ff;
            border-color: #a0c3ff;
        }

        .btn-danger, .label-danger, .progress-bar-danger {
            background-color: #dd4b39;
        }

        .btn-warning, .label-warning, .progress-bar-warning {
            background-color: #f4b400;
            color: #444444;
        }

        hr {
            border-color: #ececec;
        }

        button {
            outline: 0;
        }

        textarea {
            resize: none;
            outline: 0;
        }

        .panel .btn i, .btn span {
            color: #666666;
        }

        .panel .panel-heading {
            background-color: #ffffff;
            font-weight: 700;
            font-size: 16px;
            color: #262626;
            border-color: #ffffff;
        }

            .panel .panel-heading a {
                font-weight: 400;
                font-size: 11px;
            }

        .panel .panel-default {
            border-color: #cccccc;
        }

        .panel .panel-thumbnail {
            padding: 0;
        }

        .panel .img-circle {
            width: 50px;
            height: 50px;
        }

        .list-group-item:first-child, .list-group-item:last-child {
            border-radius: 0;
        }

        h3, h4, h5 {
            border: 0 solid #efefef;
            border-bottom-width: 1px;
            padding-bottom: 10px;
        }

        .modal-dialog {
            width: 450px;
        }

        .modal-footer {
            border-width: 0;
        }

        .dropdown-menu {
            background-color: #f4f4f4;
            border-color: #f0f0f0;
            border-radius: 0;
            margin-top: -1px;
        }
        /* end theme */
    </style>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
</head>
<body>

    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Social & cultural club", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li>@Html.ActionLink("About", "About", "Home")</li>
                    @If (User.IsInRole("SiteAdmin") Or User.IsInRole("Admin")) Then

                        @<li>@Html.ActionLink("Activities", "Index", "Activities")</li>


                    End If
                    @if(User.IsInRole("SiteAdmin")) Then
                        @<li>@Html.ActionLink("Teams", "Index", "Groups")</li>
                        @<li>@Html.ActionLink("Administration", "Index", "RegisterAdmins")</li>

                    End If
                    @if (User.IsInRole("Admin")) Then
                        @<li>@Html.ActionLink("Teams", "Index", "Groups1")</li>
                    End If
                </ul>
                @Html.Partial("_LoginPartial")
            </div>
        </div>
    </div>
    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p> &copy; @DateTime.Now.Year - Social & cultural club</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    @*<script type="text/javascript">
            $(function () { // will trigger when the document is ready
                $('.datepicker').datepicker(); //Initialise any date pickers
            });
        </script>*@
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)

</body>
</html>
