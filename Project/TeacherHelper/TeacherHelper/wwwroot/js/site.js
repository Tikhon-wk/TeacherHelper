console.dir(document.getElementById("subjects"))
let checks = document.querySelectorAll("#subjects");
for (let i = 0; i < checks.length; i++) {
    checks[i].addEventListener("change", function () {
        let data = document.getElementById("subjectsIds");
        console.dir(data);
        if (data.value == "")
            data.value = this.value;
        else
            data.value += ";" + this.value;
    });
}
//let labels = document.querySelectorAll("#label");
//let radios = document.querySelectorAll("input[type=radio]");
//for (let i = 0; i < labels.length; i++) {
//    labels[i].addEventListener("click", function () {
//        if (!radios[i].checked) {
//            console.dir(this);         
//            for (let j = 0; j < labels.length; j++) {
//                if (labels[j].style.backgroundColor != "") {
//                    labels[j].style.backgroundColor = "";
//                }
//            }
//            this.style.backgroundColor = "#343a40";
//        }
//        else {
//            this.style.backgroundColor = "";
//        }
//    });
//}