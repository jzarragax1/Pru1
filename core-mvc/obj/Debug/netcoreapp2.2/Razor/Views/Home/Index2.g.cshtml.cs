#pragma checksum "C:\githubD\Pru1\Pru1\core-mvc\Views\Home\Index2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3aca29a2d60d0ec1c23b5d72c9f6a656766db4e4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index2), @"mvc.1.0.view", @"/Views/Home/Index2.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index2.cshtml", typeof(AspNetCore.Views_Home_Index2))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\githubD\Pru1\Pru1\core-mvc\Views\_ViewImports.cshtml"
using core_mvc;

#line default
#line hidden
#line 2 "C:\githubD\Pru1\Pru1\core-mvc\Views\_ViewImports.cshtml"
using core_mvc.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3aca29a2d60d0ec1c23b5d72c9f6a656766db4e4", @"/Views/Home/Index2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a9b8feb2cf639981d498ae7aac9b29b1bd3377b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\githubD\Pru1\Pru1\core-mvc\Views\Home\Index2.cshtml"
  
    ViewData["Title"] = "Privacy Policy";

#line default
#line hidden
            BeginContext(50, 4, true);
            WriteLiteral("<h1>");
            EndContext();
            BeginContext(55, 17, false);
#line 4 "C:\githubD\Pru1\Pru1\core-mvc\Views\Home\Index2.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(72, 523, true);
            WriteLiteral(@"</h1>

<script src=""https://www.gstatic.com/firebasejs/5.9.2/firebase.js""></script>
<script>
    // Initialize Firebase
    var config = {
        apiKey: ""AIzaSyDrkSEs5jOx91krsGizo4p2xAsmgPrHzSc"",
        authDomain: ""prueba1-365d2.firebaseapp.com"",
        databaseURL: ""https://prueba1-365d2.firebaseio.com"",
        projectId: ""prueba1-365d2"",
        storageBucket: ""prueba1-365d2.appspot.com"",
        messagingSenderId: ""256425404574""
    };
    firebase.initializeApp(config);
</script>

fff



");
            EndContext();
            BeginContext(595, 4793, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3aca29a2d60d0ec1c23b5d72c9f6a656766db4e44083", async() => {
                BeginContext(601, 4780, true);
                WriteLiteral(@"


    <script type=""text/javascript"">

        /**
         * Function called when clicking the Login/Logout button.
         */
        // [START buttoncallback]
        function toggleSignIn() {
            if (!firebase.auth().currentUser) {
                // [START createprovider]
                var provider = new firebase.auth.GoogleAuthProvider();
                // [END createprovider]
                // [START addscopes]
                provider.addScope('https://www.googleapis.com/auth/contacts.readonly');
                // [END addscopes]
                // [START signin]
                firebase.auth().signInWithPopup(provider).then(function (result) {
                    // This gives you a Google Access Token. You can use it to access the Google API.
                    var token = result.credential.accessToken;
                    // The signed-in user info.
                    var user = result.user;
                    // [START_EXCLUDE]
                    document");
                WriteLiteral(@".getElementById('quickstart-oauthtoken').textContent = token;
                    // [END_EXCLUDE]
                }).catch(function (error) {
                    // Handle Errors here.
                    var errorCode = error.code;
                    var errorMessage = error.message;
                    // The email of the user's account used.
                    var email = error.email;
                    // The firebase.auth.AuthCredential type that was used.
                    var credential = error.credential;
                    // [START_EXCLUDE]
                    if (errorCode === 'auth/account-exists-with-different-credential') {
                        alert('You have already signed up with a different auth provider for that email.');
                        // If you are using multiple auth providers on your app you should handle linking
                        // the user's accounts here.
                    } else {
                        console.error(error);
            ");
                WriteLiteral(@"        }
                    // [END_EXCLUDE]
                });
                // [END signin]
            } else {
                // [START signout]
                firebase.auth().signOut();
                // [END signout]
            }
            // [START_EXCLUDE]
            document.getElementById('quickstart-sign-in').disabled = true;
            // [END_EXCLUDE]
        }
        // [END buttoncallback]

        /**
         * initApp handles setting up UI event listeners and registering Firebase auth listeners:
         *  - firebase.auth().onAuthStateChanged: This listener is called when the user is signed in or
         *    out, and that is where we update the UI.
         */
        function initApp() {
            // Listening for auth state changes.
            // [START authstatelistener]
            firebase.auth().onAuthStateChanged(function (user) {
                if (user) {
                    // User is signed in.
                    var displayName = us");
                WriteLiteral(@"er.displayName;
                    var email = user.email;
                    var emailVerified = user.emailVerified;
                    var photoURL = user.photoURL;
                    var isAnonymous = user.isAnonymous;
                    var uid = user.uid;
                    var providerData = user.providerData;
                    // [START_EXCLUDE]
                    document.getElementById('quickstart-sign-in-status').textContent = 'Signed in';
                    document.getElementById('quickstart-sign-in').textContent = 'Sign out';
                    document.getElementById('quickstart-account-details').textContent = JSON.stringify(user, null, '  ');
                    // [END_EXCLUDE]
                } else {
                    // User is signed out.
                    // [START_EXCLUDE]
                    document.getElementById('quickstart-sign-in-status').textContent = 'Signed out';
                    document.getElementById('quickstart-sign-in').textContent = 'Sign ");
                WriteLiteral(@"in with Google';
                    document.getElementById('quickstart-account-details').textContent = 'null';
                    document.getElementById('quickstart-oauthtoken').textContent = 'null';
                    // [END_EXCLUDE]
                }
                // [START_EXCLUDE]
                document.getElementById('quickstart-sign-in').disabled = false;
                // [END_EXCLUDE]
            });
            // [END authstatelistener]

            document.getElementById('quickstart-sign-in').addEventListener('click', toggleSignIn, false);
        }

        window.onload = function () {
            initApp();
        };
    </script>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5388, 2116, true);
            WriteLiteral(@"




<div class=""demo-layout mdl-layout mdl-js-layout mdl-layout--fixed-header"">

    <!-- Header section containing title -->
    <header class=""mdl-layout__header mdl-color-text--white mdl-color--light-blue-700"">
        <div class=""mdl-cell mdl-cell--12-col mdl-cell--12-col-tablet mdl-grid"">
            <div class=""mdl-layout__header-row mdl-cell mdl-cell--12-col mdl-cell--12-col-tablet mdl-cell--8-col-desktop"">
                <a href=""/""><h3>Firebase Authentication</h3></a>
            </div>
        </div>
    </header>

    <main class=""mdl-layout__content mdl-color--grey-100"">
        <div class=""mdl-cell mdl-cell--12-col mdl-cell--12-col-tablet mdl-grid"">

            <!-- Container for the demo -->
            <div class=""mdl-card mdl-shadow--2dp mdl-cell mdl-cell--12-col mdl-cell--12-col-tablet mdl-cell--12-col-desktop"">
                <div class=""mdl-card__title mdl-color--light-blue-600 mdl-color-text--white"">
                    <h2 class=""mdl-card__title-text"">Google Auth");
            WriteLiteral(@"entication with Popup</h2>
                </div>
                <div class=""mdl-card__supporting-text mdl-color-text--grey-600"">
                    <p>Sign in with your Google account below.</p>

                    <!-- Button that handles sign-in/sign-out -->
                    <button disabled class=""mdl-button mdl-js-button mdl-button--raised"" id=""quickstart-sign-in"">Sign in with Google</button>

                    <!-- Container where we'll display the user details -->
                    <div class=""quickstart-user-details-container"">
                        Firebase sign-in status: <span id=""quickstart-sign-in-status"">Unknown</span>
                        <div>Firebase auth <code>currentUser</code> object value:</div>
                        <pre><code id=""quickstart-account-details"">null</code></pre>
                        <div>Google OAuth Access Token:</div>
                        <pre><code id=""quickstart-oauthtoken"">null</code></pre>
                    </div>
             ");
            WriteLiteral("   </div>\r\n            </div>\r\n        </div>\r\n    </main>\r\n</div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
