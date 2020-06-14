// JavaScript source code


(function () {

    const config = {
        apiKey: "AIzaSyBJ_ereMPOcvOSJPZk4TKR_NFrfnQ49AQk",
        authDomain: "cse-405-project.firebaseapp.com",
        databaseURL: "https://cse-405-project.firebaseio.com",
        projectId: "cse-405-project",
        storageBucket: "cse-405-project.appspot.com",
        messagingSenderId: "938591196493",
        appId: "1:938591196493:web:36ef87dfe6109573ddd304",
        measurementId: "G-J98K3WNZWT"
    };


    if (!firebase.apps.length) {
        firebase.initializeApp(config);
    }


    function verifyLogin() {
        var user = firebase.auth().currentUser
        if (!user.isEmailVerified) {
            signup_verify.style.display = "block"
            verify_btn.addEventListener('click', verifyEmail)
        }
        else {
            console.log('verified')
            login()
        }

    }

    function gLogin() {
        const email = a_email.value;
        const pass = a_pass.value;
        const auth = firebase.auth();

        const promise = auth.signInWithEmailAndPassword(email, pass);
        promise.catch(function (error) {
            var errorCode = error.code;
            var errorMessage = error.message;
            if (errorCode === 'auth/wrong-password') {
                errorLogin.style.display = "block"
            } else {
                alert(errorMessage);
            }
        });
        promise.then(function () {
            login()
        });

    }

    function login() {
        a_logged_in.style.display = "block"
        a_logging_in.style.display = "none"
        download_info.style.display = "none"
        signin_thanks.style.display = "block"
        a_download_link.style.display = "block"
        a_logout_btn.addEventListener('click', gLogout)
        signup_verify.style.display = "none"
        score_list.style.display = "block"
    }


    function gLogout() {
        const auth = firebase.auth();
        logout();
        auth.signOut();
    }

    function logout() {
        a_logging_in.style.display = "block"
        a_logged_in.style.display = "none"
        signup_error.style.display = "none"
        signup_verify.style.display = "none"
        a_download_link.style.display = "none"
        score_list.style.display = "none"

        download_info.style.display = "block"
        signin_thanks.style.display = "none"

        a_login_btn.addEventListener('click', gLogin)
        a_sign_up.addEventListener('click', signup)
    }

    function signup() {
        if (a_email.value == "") {
            signup_error.style.display = "block"
        }
        const email = a_email.value;
        const pass = a_pass.value;
        const auth = firebase.auth();

        const promise = auth.createUserWithEmailAndPassword(email, pass);
        promise.catch(function (error) {
            var errorCode = error.code;
            var errorMessage = error.message;
            if (errorCode == 'auth/email-already-in-use') {
                //alert('This email is already in use.');
                signupError_user.style.display = "block";
            } else {
                alert(errorMessage);
            }
        });
        promise.then(function () {
            verifyLogin()
        });
    }

    function verifyEmail() {
        var user = firebase.auth().currentUser
        user.sendEmailVerification().then(function () {
            console.log('email sent')
            firebase.auth().signOut();
            logout();
        }).catch(function (error) {
            console.log('no email sent')
        })
    }

    document.addEventListener('DOMContentLoaded', () => {

        if (true) {
            if (true) {
                if (!firebase.auth().currentUser) {
                    console.log('no users')
                    logout();
                }
                else {
                    firebase.auth().onAuthStateChanged(firebaseUser => {
                        if (firebaseUser.isEmailVerified) {
                            console.log(firebaseUser)
                            login();
                        }
                        else {
                            console.log('verified')
                            //logout();
                        }
                    });
                }
            }
        }
        else {
            a_logging_in.style.display = "block"
            a_login_btn.addEventListener('click', login)
        }

    })


}());