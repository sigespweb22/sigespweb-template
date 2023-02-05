# Sigesp for ASP.NET Core 3.1

Sigesp for ASP.NET Core is an open-source and cross-platform framework for building modern cloud based internet connected applications, such as web apps, IoT apps and mobile backends. Sigesp for ASP.NET Core apps can run on .NET Core or on the full .NET Framework. It was architected to provide an optimized development framework for apps that are deployed to the cloud or run on-premises. It consists of modular components with minimal overhead, so you retain flexibility while constructing your solutions. You can develop and run your Sigesp for ASP.NET Core apps cross-platform on Windows, Mac and Linux. [Learn more about ASP.NET Core](https://docs.microsoft.com/aspnet/core/).

## Get Started

Follow the **Getting Started** instructions in the Sigesp for ASP.NET Core **docs** folder or directly from the **ASP.NET Core 3.1** menu after launching the website locally.

Or use the following instructions to setup a local server running Sigesp for ASP.NET Core:

1. Download and install the **ASP.NET Core 3.1 SDK** here: https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.102-windows-x64-installer
    * You can verify the installation by opening a command line tool of your choice and running the following command: `dotnet --info`
    * If you get a message similar to: `dotnet is not recognized as an internal command`, then please try downloading the `32-bit` version of the ASP.NET Core 3.1 SDK
    * You can find it here: https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.102-windows-x86-installer
1. Download and install **SQL Server Express** here: https://go.microsoft.com/fwlink/?linkid=853017
    * Note: You can also install **LocalDB** as part of Visual Studio. During Visual Studio installation, select the **.NET desktop development** workload, which includes SQL Server Express LocalDB.
    * If you are going to SQL Express then the default connection string *value* in `appSettings.json` will need to be adjusted
    * The value and instructions are written in `Startup.cs` but also listed here for your convinience:
    * `"Server=localhost\\SQLEXPRESS;Database=aspnet-smartadmin;Trusted_Connection=True;MultipleActiveResultSets=true"`
1. Open a command prompt and ensure you are inside the directory containing the **ASP.NET Core 3.1 project sources** of Sigesp 4.0
    * This is the directory containing the `SigespCore.sln` file
1. Run the following commands (in order) using the command line tool of your choice:
    * `dotnet build`
    * `dotnet publish` *(optional for localhost only deployment)*
    * `dotnet run --project ./src/Sigesp.WebUI/Sigesp.WebUI.csproj`
1. Launch your favorite browser and enter the following URL: https://localhost:5001, and try to login using the provided credentials
    * You may get a page mentioning that: 'Applying the existing migrations may resolve this issue'
    * Go ahead and click on the blue `Apply Migrations` button
1. If you receive a message stating: 'Invalid login attempt' then go ahead and Register the user
    * The username and password should be prefilled for demo purposes

> Note: You might get a security warning when browsing to your website, as the default `localhost` server will typically not have a trusted **localhost** SSL certificate!

Also check out the [.NET Homepage](https://www.microsoft.com/net) for released versions of .NET, getting started guides, and learning resources.

## How to Engage, Contribute, and Give Feedback

Some of the best ways to contribute are to try things out, file issues, join in design conversations, and make pull-requests.

* Download our latest builds
* Follow along with the development of Sigesp for ASP.NET Core:
  * [Roadmap](https://support.gotbootstrap.com/t/asp-net-core): The schedule and milestone themes for Sigesp for ASP.NET Core.
* Check out the [contributing](CONTRIBUTING.md) page to see the best places to log issues and start discussions.

## Reporting security issues and bugs

Security issues and bugs should be reported privately, via email, to Sigesp Security (SAC) at <secure@walapa.nl>. You should receive a response within 72 hours. If for some reason you do not, please follow up via email to ensure we received your original message.

## Code of conduct

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).  For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [smartadmin-next@walapa.nl](mailto:smartadmin-next@walapa.nl) with any additional questions or comments.


<!-- {
  "version": "4.5",
  "lists": [
    {
      "title": "Application Intel",
      "icon": "fal fa-info-circle",
      "roles": [],
      "items": [
        {
          "title": "Analytics Dashboard",
          "showOnSeed": false,
          "href": "intel_analytics_dashboard.html",
          "roles": []
        },
        {
          "title": "Marketing Dashboard",
          "showOnSeed": false,
          "href": "intel_marketing_dashboard.html",
          "roles": []
        },
        {
          "title": "Introduction",
          "href": "intel_introduction.html",
          "roles": []
        },
        {
          "title": "Privacy",
          "href": "intel_privacy.html",
          "roles": []
        }
      ]
    },
    {
      "title": "Theme Settings",
      "icon": "fal fa-cog",
      "roles": [],
      "items": [
        {
          "title": "How it works",
          "href": "settings_how_it_works.html",
          "roles": []
        },
        {
          "title": "Layout Options",
          "href": "settings_layout_options.html",
          "roles": []
        },
        {
          "title": "Theme Modes (beta)",
          "href": "settings_theme_modes.html",
          "roles": []
        },
        {
          "title": "Skin Options",
          "href": "settings_skin_options.html",
          "roles": []
        },
        {
          "title": "Saving to Database",
          "href": "settings_saving_db.html",
          "roles": []
        }
      ]
    },
    {
      "title": "Documentation",
      "showOnSeed": false,
      "icon": "fal fa-book",
      "roles": [],
      "items": [
        {
          "title": "General Docs",
          "href": "docs_general.html",
          "roles": []
        },
        {
          "title": "Flavors & Editions",
          "href": "docs_flavors_editions.html",
          "roles": []
        },
        {
          "title": "Community Support",
          "href": "docs_community_support.html",
          "roles": []
        },
        {
          "title": "Licensing",
          "href": "docs_licensing.html",
          "roles": []
        },
        {
          "title": "Build Notes",
          "text": "Build Notes",
          "href": "docs_buildnotes.html",
          "span": {
            "text": "v4.5.1"
          },
          "roles": []
        }
      ]
    },
    {
      "title": "ASP.NET Core 3.1",
      "roles": []
    },
    {
      "title": "Welcome",
      "href": "aspnetcore_welcome.html",
      "icon": "fal fa-graduation-cap",
      "roles": []
    },
    {
      "title": "Authorization",
      "icon": "fal fa-shield-alt",
      "roles": [
        "Administrator"
      ],
      "items": [
        {
          "title": "Users",
          "href": "authorization_users.html",
          "roles": []
        },
        {
          "title": "Roles",
          "href": "authorization_roles.html",
          "roles": []
        }
      ]
    },
    {
      "title": "Solution Overview",
      "icon": "fal fa-folder-open",
      "roles": [],
      "items": [
        {
          "title": "Editions",
          "showOnSeed": false,
          "href": "aspnetcore_editions.html",
          "roles": []
        },
        {
          "title": "FAQ",
          "href": "aspnetcore_faq.html",
          "roles": []
        },
        {
          "title": "Interactive",
          "showOnSeed": false,
          "href": "aspnetcore_interactive.html",
          "roles": []
        }
      ]
    },
    {
      "title": "Documentation",
      "icon": "fal fa-book",
      "roles": [],
      "items": [
        {
          "title": "Introduction",
          "href": "documentation_introduction.html",
          "roles": []
        },
        {
          "title": "Getting Started",
          "href": "documentation_getting_started.html",
          "roles": []
        },
        {
          "title": "Site Structure",
          "href": "documentation_site_structure.html",
          "roles": []
        },
        {
          "title": "Solution Architecture",
          "href": "documentation_solution_architecture.html",
          "roles": []
        },
        {
          "title": "Customizations",
          "href": "documentation_customizations.html",
          "roles": []
        },
        {
          "title": "Howto Contribute",
          "href": "documentation_howto_contribute.html",
          "roles": []
        },
        {
          "title": "Licensing Information",
          "href": "documentation_licensing_information.html",
          "roles": []
        },
        {
          "title": "Changelog",
          "href": "documentation_changelog.html",
          "roles": []
        }
      ]
    },
    {
      "title": "Tools & Components",
      "roles": [
        "Administrator"
      ]
    },
    {
      "title": "UI Components",
      "icon": "fal fa-window",
      "roles": [
        "Administrator"
      ],
      "items": [
        {
          "title": "Alerts",
          "href": "ui_alerts.html",
          "roles": []
        },
        {
          "title": "Accordions",
          "href": "ui_accordion.html",
          "roles": []
        },
        {
          "title": "Badges",
          "href": "ui_badges.html",
          "roles": []
        },
        {
          "title": "Breadcrumbs",
          "href": "ui_breadcrumbs.html",
          "roles": []
        },
        {
          "title": "Buttons",
          "href": "ui_buttons.html",
          "roles": []
        },
        {
          "title": "Button Group",
          "href": "ui_button_group.html",
          "roles": []
        },
        {
          "title": "Cards",
          "href": "ui_cards.html",
          "roles": []
        },
        {
          "title": "Carousel",
          "href": "ui_carousel.html",
          "roles": []
        },
        {
          "title": "Collapse",
          "href": "ui_collapse.html",
          "roles": []
        },
        {
          "title": "Dropdowns",
          "href": "ui_dropdowns.html",
          "roles": []
        },
        {
          "title": "List Filter",
          "href": "ui_list_filter.html",
          "roles": []
        },
        {
          "title": "Modal",
          "href": "ui_modal.html",
          "roles": []
        },
        {
          "title": "Navbars",
          "href": "ui_navbars.html",
          "roles": []
        },
        {
          "title": "Panels",
          "href": "ui_panels.html",
          "roles": []
        },
        {
          "title": "Pagination",
          "href": "ui_pagination.html",
          "roles": []
        },
        {
          "title": "Popovers",
          "href": "ui_popovers.html",
          "roles": []
        },
        {
          "title": "Progress Bars",
          "href": "ui_progress_bars.html",
          "roles": []
        },
        {
          "title": "ScrollSpy",
          "href": "ui_scrollspy.html",
          "roles": []
        },
        {
          "title": "Side Panel",
          "href": "ui_side_panel.html",
          "roles": []
        },
        {
          "title": "Spinners",
          "href": "ui_spinners.html",
          "roles": []
        },
        {
          "title": "Tabs & Pills",
          "href": "ui_tabs_pills.html",
          "roles": []
        },
        {
          "title": "Toasts",
          "href": "ui_toasts.html",
          "roles": []
        },
        {
          "title": "Tooltips",
          "href": "ui_tooltips.html",
          "roles": []
        }
      ]
    },
    {
      "title": "Utilities",
      "icon": "fal fa-bolt",
      "roles": [
        "Administrator"
      ],
      "items": [
        {
          "title": "Borders",
          "href": "utilities_borders.html",
          "roles": []
        },
        {
          "title": "Clearfix",
          "href": "utilities_clearfix.html",
          "roles": []
        },
        {
          "title": "Color Pallet",
          "href": "utilities_color_pallet.html",
          "roles": []
        },
        {
          "title": "Display Property",
          "href": "utilities_display_property.html",
          "roles": []
        },
        {
          "title": "Fonts",
          "href": "utilities_fonts.html",
          "roles": []
        },
        {
          "title": "Flexbox",
          "href": "utilities_flexbox.html",
          "roles": []
        },
        {
          "title": "Helpers",
          "href": "utilities_helpers.html",
          "roles": []
        },
        {
          "title": "Position",
          "href": "utilities_position.html",
          "roles": []
        },
        {
          "title": "Responsive Grid",
          "href": "utilities_responsive_grid.html",
          "roles": []
        },
        {
          "title": "Sizing",
          "href": "utilities_sizing.html",
          "roles": []
        },
        {
          "title": "Spacing",
          "href": "utilities_spacing.html",
          "roles": []
        },
        {
          "title": "Typography",
          "tags": "fonts headings bold lead colors sizes link text states list styles truncate alignment",
          "href": "utilities_typography.html",
          "roles": []
        },
        {
          "title": "Menu child",
          "href": "javascript:void(0);",
          "roles": [],
          "items": [
            {
              "title": "Sublevel Item",
              "href": "javascript:void(0);",
              "roles": []
            },
            {
              "title": "Another Item",
              "href": "javascript:void(0);",
              "roles": []
            }
          ]
        },
        {
          "title": "Disabled item",
          "disabled": true,
          "href": "javascript:void(0);",
          "roles": []
        }
      ]
    },
    {
      "title": "Font Icons",
      "icon": "fal fa-map-marker-alt",
      "span": {
        "class": "dl-ref bg-primary-500 hidden-nav-function-minify hidden-nav-function-top",
        "text": "7,500+"
      },
      "roles": [],
      "items": [
        {
          "title": "FontAwesome",
          "text": "FontAwesome Pro",
          "href": "javascript:void(0);",
          "roles": [],
          "items": [
            {
              "title": "Light",
              "href": "icons_fontawesome_light.html",
              "roles": []
            },
            {
              "title": "Regular",
              "href": "icons_fontawesome_regular.html",
              "roles": []
            },
            {
              "title": "Solid",
              "href": "icons_fontawesome_solid.html",
              "roles": []
            },
            {
              "title": "Duotone",
              "href": "icons_fontawesome_duotone.html",
              "roles": []
            },
            {
              "title": "Brand",
              "href": "icons_fontawesome_brand.html",
              "roles": []
            }
          ]
        },
        {
          "title": "NextGen Icons",
          "href": "javascript:void(0);",
          "roles": [],
          "items": [
            {
              "title": "General",
              "href": "icons_nextgen_general.html",
              "roles": []
            },
            {
              "title": "Base",
              "href": "icons_nextgen_base.html",
              "roles": []
            }
          ]
        },
        {
          "title": "Stack Icons",
          "href": "javascript:void(0);",
          "roles": [],
          "items": [
            {
              "title": "Showcase",
              "href": "icons_stack_showcase.html",
              "roles": []
            },
            {
              "title": "Generate Stack",
              "href": "icons_stack_generate.html?layers=3",
              "roles": []
            }
          ]
        }
      ]
    },
    {
      "title": "Tables",
      "icon": "fal fa-th-list",
      "roles": [],
      "items": [
        {
          "title": "Basic Tables",
          "href": "tables_basic.html",
          "roles": []
        },
        {
          "title": "Generate Table Style",
          "href": "tables_generate_style.html",
          "roles": []
        }
      ]
    },
    {
      "title": "Form Stuff",
      "icon": "fal fa-edit",
      "roles": [],
      "items": [
        {
          "title": "Basic Inputs",
          "href": "form_basic_inputs.html",
          "roles": []
        },
        {
          "title": "Checkbox & Radio",
          "href": "form_checkbox_radio.html",
          "roles": []
        },
        {
          "title": "Input Groups",
          "href": "form_input_groups.html",
          "roles": []
        },
        {
          "title": "Validation",
          "href": "form_validation.html",
          "roles": []
        }
      ]
    },
    {
      "title": "Plugins & Addons",
      "roles": []
    },
    {
      "title": "Plugins",
      "text": "Core Plugins",
      "icon": "fal fa-shield-alt",
      "roles": [],
      "items": [
        {
          "title": "Plugins FAQ",
          "href": "plugins_faq.html",
          "roles": []
        },
        {
          "title": "Waves",
          "href": "plugins_waves.html",
          "span": {
            "class": "dl-ref label bg-primary-400 ml-2",
            "text": "9 KB"
          },
          "roles": []
        },
        {
          "title": "PaceJS",
          "href": "plugins_pacejs.html",
          "span": {
            "class": "dl-ref label bg-primary-500 ml-2",
            "text": "13 KB"
          },
          "roles": []
        },
        {
          "title": "SmartPanels",
          "href": "plugins_smartpanels.html",
          "span": {
            "class": "dl-ref label bg-primary-600 ml-2",
            "text": "9 KB"
          },
          "roles": []
        },
        {
          "title": "BootBox",
          "tags": "alert sound",
          "href": "plugins_bootbox.html",
          "span": {
            "class": "dl-ref label bg-primary-600 ml-2",
            "text": "15 KB"
          },
          "roles": []
        },
        {
          "title": "Slimscroll",
          "href": "plugins_slimscroll.html",
          "span": {
            "class": "dl-ref label bg-primary-700 ml-2",
            "text": "5 KB"
          },
          "roles": []
        },
        {
          "title": "Throttle",
          "href": "plugins_throttle.html",
          "span": {
            "class": "dl-ref label bg-primary-700 ml-2",
            "text": "1 KB"
          },
          "roles": []
        },
        {
          "title": "Navigation",
          "href": "plugins_navigation.html",
          "span": {
            "class": "dl-ref label bg-primary-700 ml-2",
            "text": "2 KB"
          },
          "roles": []
        },
        {
          "title": "i18next",
          "href": "plugins_i18next.html",
          "span": {
            "class": "dl-ref label bg-primary-700 ml-2",
            "text": "10 KB"
          },
          "roles": []
        },
        {
          "title": "App.Core",
          "href": "plugins_appcore.html",
          "span": {
            "class": "dl-ref label bg-success-700 ml-2",
            "text": "14 KB"
          },
          "roles": []
        }
      ]
    },
    {
      "title": "Datatables",
      "tags": "datagrid",
      "showOnSeed": false,
      "icon": "fal fa-table",
      "span": {
        "class": "dl-ref bg-primary-500 hidden-nav-function-minify hidden-nav-function-top",
        "text": "235 KB"
      },
      "roles": [],
      "items": [
        {
          "title": "Basic",
          "href": "datatables_basic.html",
          "roles": []
        },
        {
          "title": "Autofill",
          "href": "datatables_autofill.html",
          "roles": []
        },
        {
          "title": "Buttons",
          "href": "datatables_buttons.html",
          "roles": []
        },
        {
          "title": "Export",
          "tags": "tables pdf excel print csv",
          "href": "datatables_export.html",
          "roles": []
        },
        {
          "title": "ColReorder",
          "href": "datatables_colreorder.html",
          "roles": []
        },
        {
          "title": "ColumnFilter",
          "href": "datatables_columnfilter.html",
          "roles": []
        },
        {
          "title": "FixedColumns",
          "href": "datatables_fixedcolumns.html",
          "roles": []
        },
        {
          "title": "FixedHeader",
          "href": "datatables_fixedheader.html",
          "roles": []
        },
        {
          "title": "KeyTable",
          "href": "datatables_keytable.html",
          "roles": []
        },
        {
          "title": "Responsive",
          "href": "datatables_responsive.html",
          "roles": []
        },
        {
          "title": "Responsive Alt",
          "href": "datatables_responsive_alt.html",
          "roles": []
        },
        {
          "title": "RowGroup",
          "href": "datatables_rowgroup.html",
          "roles": []
        },
        {
          "title": "RowReorder",
          "href": "datatables_rowreorder.html",
          "roles": []
        },
        {
          "title": "Scroller",
          "href": "datatables_scroller.html",
          "roles": []
        },
        {
          "title": "Select",
          "href": "datatables_select.html",
          "roles": []
        },
        {
          "title": "AltEditor",
          "href": "datatables_alteditor.html",
          "roles": []
        }
      ]
    },
    {
      "title": "Statistics",
      "tags": "chart, graphs",
      "showOnSeed": false,
      "icon": "fal fa-chart-pie",
      "roles": [
        "Administrator"
      ],
      "items": [
        {
          "title": "Flot",
          "tags": "bar pie",
          "href": "statistics_flot.html",
          "span": {
            "class": "dl-ref label bg-primary-500 ml-2",
            "text": "36 KB"
          },
          "roles": []
        },
        {
          "title": "Chart.js",
          "tags": "bar pie",
          "href": "statistics_chartjs.html",
          "span": {
            "class": "dl-ref label bg-primary-500 ml-2",
            "text": "205 KB"
          },
          "roles": []
        },
        {
          "title": "Chartist.js",
          "href": "statistics_chartist.html",
          "span": {
            "class": "dl-ref label bg-primary-600 ml-2",
            "text": "39 KB"
          },
          "roles": []
        },
        {
          "title": "C3 Charts",
          "href": "statistics_c3.html",
          "span": {
            "class": "dl-ref label bg-primary-600 ml-2",
            "text": "197 KB"
          },
          "roles": []
        },
        {
          "title": "Peity",
          "tags": "small",
          "href": "statistics_peity.html",
          "span": {
            "class": "dl-ref label bg-primary-700 ml-2",
            "text": "4 KB"
          },
          "roles": []
        },
        {
          "title": "Sparkline",
          "tags": "small tiny",
          "href": "statistics_sparkline.html",
          "span": {
            "class": "dl-ref label bg-primary-700 ml-2",
            "text": "42 KB"
          },
          "roles": []
        },
        {
          "title": "Easy Pie Chart",
          "href": "statistics_easypiechart.html",
          "span": {
            "class": "dl-ref label bg-primary-700 ml-2",
            "text": "4 KB"
          },
          "roles": []
        },
        {
          "title": "Dygraph",
          "tags": "complex",
          "href": "statistics_dygraph.html",
          "span": {
            "class": "dl-ref label bg-primary-700 ml-2",
            "text": "120 KB"
          },
          "roles": []
        }
      ]
    },
    {
      "title": "Notifications",
      "showOnSeed": false,
      "icon": "fal fa-exclamation-circle",
      "roles": [
        "Administrator"
      ],
      "items": [
        {
          "title": "SweetAlert2",
          "href": "notifications_sweetalert2.html",
          "span": {
            "class": "dl-ref label bg-primary-500 ml-2",
            "text": "40 KB"
          },
          "roles": []
        },
        {
          "title": "Toastr",
          "href": "notifications_toastr.html",
          "span": {
            "class": "dl-ref label bg-primary-600 ml-2",
            "text": "5 KB"
          },
          "roles": []
        }
      ]
    },
    {
      "title": "Form Plugins",
      "showOnSeed": false,
      "icon": "fal fa-credit-card-front",
      "roles": [],
      "items": [
        {
          "title": "Color Picker",
          "href": "form_plugins_colorpicker.html",
          "roles": []
        },
        {
          "title": "Date Picker",
          "href": "form_plugins_datepicker.html",
          "roles": []
        },
        {
          "title": "Date Range Picker",
          "href": "form_plugins_daterange_picker.html",
          "roles": []
        },
        {
          "title": "Dropzone",
          "href": "form_plugins_dropzone.html",
          "roles": []
        },
        {
          "title": "Ion.RangeSlider",
          "href": "form_plugins_ionrangeslider.html",
          "roles": []
        },
        {
          "title": "Inputmask",
          "href": "form_plugins_inputmask.html",
          "roles": []
        },
        {
          "title": "Image Cropper",
          "href": "form_plugins_imagecropper.html",
          "roles": []
        },
        {
          "title": "Select2",
          "href": "form_plugins_select2.html",
          "roles": []
        },
        {
          "title": "Summernote",
          "tags": "texteditor editor",
          "href": "form_plugins_summernote.html",
          "roles": []
        }
      ]
    },
    {
      "title": "Miscellaneous",
      "showOnSeed": false,
      "icon": "fal fa-globe",
      "roles": [],
      "items": [
        {
          "title": "FullCalendar",
          "href": "miscellaneous_fullcalendar.html",
          "roles": []
        },
        {
          "title": "Light Gallery",
          "href": "miscellaneous_lightgallery.html",
          "span": {
            "class": "dl-ref label bg-primary-500 ml-2",
            "text": "61 KB"
          },
          "roles": []
        }
      ]
    },
    {
      "title": "Layouts & Apps",
      "roles": []
    },
    {
      "title": "Pages",
      "text": "Page Views",
      "icon": "fal fa-plus-circle",
      "roles": [],
      "items": [
        {
          "title": "Chat",
          "href": "page_chat.html",
          "roles": []
        },
        {
          "title": "Contacts",
          "href": "page_contacts.html",
          "roles": []
        },
        {
          "title": "Forum",
          "href": "javascript:void(0);",
          "roles": [],
          "items": [
            {
              "title": "List",
              "href": "page_forum_list.html",
              "roles": []
            },
            {
              "title": "Threads",
              "href": "page_forum_threads.html",
              "roles": []
            },
            {
              "title": "Discussion",
              "href": "page_forum_discussion.html",
              "roles": []
            }
          ]
        },
        {
          "title": "Inbox",
          "href": "javascript:void(0);",
          "roles": [],
          "items": [
            {
              "title": "General",
              "href": "page_inbox_general.html",
              "roles": []
            },
            {
              "title": "Read",
              "href": "page_inbox_read.html",
              "roles": []
            },
            {
              "title": "Write",
              "href": "page_inbox_write.html",
              "roles": []
            }
          ]
        },
        {
          "title": "Invoice (printable)",
          "href": "page_invoice.html",
          "roles": []
        },
        {
          "title": "Authentication",
          "href": "javascript:void(0);",
          "roles": [],
          "items": [
            {
              "title": "Forget Password",
              "href": "page_forget.html",
              "roles": []
            },
            {
              "title": "Locked Screen",
              "href": "page_locked.html",
              "roles": []
            },
            {
              "title": "Login",
              "href": "page_login.html",
              "roles": []
            },
            {
              "title": "Login Alt",
              "href": "page_login_alt.html",
              "roles": []
            },
            {
              "title": "Register",
              "href": "page_register.html",
              "roles": []
            },
            {
              "title": "Confirmation",
              "href": "page_confirmation.html",
              "roles": []
            }
          ]
        },
        {
          "title": "Error Pages",
          "href": "javascript:void(0);",
          "roles": [],
          "items": [
            {
              "title": "General Error",
              "href": "page_error.html",
              "roles": []
            },
            {
              "title": "Server Error",
              "href": "page_error_404.html",
              "roles": []
            },
            {
              "title": "Announced Error",
              "href": "page_error_announced.html",
              "roles": []
            }
          ]
        },
        {
          "title": "Profile",
          "href": "page_profile.html",
          "roles": []
        },
        {
          "title": "Projects",
          "showOnSeed": false,
          "href": "page_projects.html",
          "roles": []
        },
        {
          "title": "Search Results",
          "href": "page_search.html",
          "roles": []
        }
      ]
    }
  ]
} -->

<!-- Seeder para criação de roles, usuários e usuarios roles
protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Seeding a  'Administrator' role to AspNetRoles table
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole {Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() });


        //a hasher to hash the password before seeding the user to the db
        var hasher = new PasswordHasher<IdentityUser>();


        //Seeding the User to AspNetUsers table
        modelBuilder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                UserName = "myuser",
                NormalizedUserName = "MYUSER",
                PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
            }
        );


        //Seeding the relation between our user and role to AspNetUserRoles table
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210", 
                UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            }
        );
        

    }

    ew AspNetRoles
                    {
                        Id = "4b6b32b8-c9c2-475f-830d-2d9486693cca",
                        Name = "Usuarios",
                        NormalizedName = "USUARIOS",
                        ConcurrencyStamp = "854f34d4-c4b4-4922-9231-d9d74722eb9a",
                    },
                    new AspNetRoles
                    {
                        Id = "f072e722-ecb5-4afc-957d-2d35c5521257",
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR",
                        ConcurrencyStamp = "6cc062e6-6965-4f05-9dd1-afb1130be5d5",
                    } -->