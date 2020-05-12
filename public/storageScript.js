// JavaScript source code
(function () {

    function download() {
        var storage = firebase.storage()
        var storageRef = storage.ref();

        var ejRef = storageRef.child('TEST.apk')

        var ejURL = storage.refFromURL('gs://cse-405-project.appspot.com/TEST.apk')


        ejURL.getDownloadURL().then(function (url) {
            // `url` is the download URL for 'images/stars.jpg'

            // This can be downloaded directly:
            var xhr = new XMLHttpRequest();
            xhr.responseType = 'blob';
            xhr.onload = function (event) {
                var blob = xhr.response;
            };
            xhr.open('GET', url);
            xhr.send();
            test('EscapingJerpa', url)
        }).catch(function (error) {
            console.log(error);
            console.log('didnt wprk boss');
        });

        //var ejURL = storage.refFromURL('gs://cse-405-project.appspot.com/TEST.apk')
    }

    document.addEventListener('DOMContentLoaded', () => {
        download_btn.addEventListener('click', download)
    })

    function test(file, text) {

        //creating an invisible element 
        var element = document.createElement('a');
        element.setAttribute('href', text);
        element.setAttribute('download', file);

        //the above code is equivalent to 
        // <a href="path of file" download="file name"> 

        document.body.appendChild(element);

        //onClick property 
        element.click();

        document.body.removeChild(element);
    }


}());