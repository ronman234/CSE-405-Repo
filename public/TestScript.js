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


    function login() {
        console.log('Clikced');
        const email = a_email.value;
        const pass = a_pass.value;
        const auth = firebase.auth();

        const promise = auth.signInWithEmailAndPassword(email, pass);
        promise.catch(e => console.log(e.message))

        a_logged_in.style.display = "block"
        a_msg.innerHTMML = "logged in"
        a_logging_in.style.display = "none"
        a_logged_in.style.display = "block"
        a_logout_btn.addEventListener('click', logout)
        a_sign_up.addEventListener('click', signup)
    }

    function logout() {
        const auth = firebase.auth();
        a_logging_in.style.display = "block"
        a_logged_in.style.display = "none"
        signup_error.style.display = "none"
        a_login_btn.addEventListener('click', login)
        a_sign_up.addEventListener('click', signup)
        auth.signOut()
    }


    function signup() {
        if (a_email.value == "") {
            signup_error.style.display = "block"
            console.log('nothing to signup')
        }
        const email = a_email.value;
        const pass = a_pass.value;
        const auth = firebase.auth();

        const promise = auth.createUserWithEmailAndPassword(email, pass);
        promise.catch(e => console.log(e.message))
        
    }

    document.addEventListener('DOMContentLoaded', () => {

        if (true) {
            if (true) {
                
                logout();
            }
        }
        else {
            a_logging_in.style.display = "block"
            a_login_btn.addEventListener('click', logout)
        }


    })


    firebase.auth().onAuthStateChanged(firebaseUser => {
        if (firebaseUser) {
            console.log(firebaseUser)
        }
        else {
            console.log('not logged in')
        }
    });

} () );