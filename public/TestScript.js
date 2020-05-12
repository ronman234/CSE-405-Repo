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
            a_logged_in.style.display = "block"
            a_logging_in.style.display = "none"
            a_download_link.style.display = "block"
            a_logout_btn.addEventListener('click', gLogout)
            signup_verify.style.display = "none"
        }

    }

    function login() {
        a_logged_in.style.display = "block"
        a_logging_in.style.display = "none"
        a_download_link.style.display = "block"
        a_logout_btn.addEventListener('click', gLogout)
        signup_verify.style.display = "none"
    }

    function gLogin() {
        const email = a_email.value;
        const pass = a_pass.value;
        const auth = firebase.auth();

        const promise = auth.signInWithEmailAndPassword(email, pass);
        promise.then(function () {
            login()
        });

    }

    function logout() {
        a_logging_in.style.display = "block"
        a_logged_in.style.display = "none"
        signup_error.style.display = "none"
        signup_verify.style.display = "none"
        a_download_link.style.display = "none"
        a_login_btn.addEventListener('click', gLogin)
        a_sign_up.addEventListener('click', signup)
    }

    function gLogout() {
        const auth = firebase.auth();
        logout();
        auth.signOut();
    }

    function signup() {
        if (a_email.value == "") {
            signup_error.style.display = "block"
        }
        const email = a_email.value;
        const pass = a_pass.value;
        const auth = firebase.auth();

        const promise = auth.createUserWithEmailAndPassword(email, pass);
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
                firebase.auth().onAuthStateChanged(firebaseUser => {
                    if (firebaseUser) {
                        console.log(firebaseUser)
                        login();
                    }
                    else {
                        console.log('not logged in')
                        logout();
                    }
                });
            }
        }
        else {
            a_logging_in.style.display = "block"
            a_login_btn.addEventListener('click', login)
        }

    })

} () );