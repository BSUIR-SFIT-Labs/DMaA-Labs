window.onload = function () {
  var amountOfClasses = 3;
  var numOfAttributes = 2;

  var teachingVectors = Array(amountOfClasses).fillArrayRandom(numOfAttributes + 1, -10, 10);
  var funcs = Array(amountOfClasses).fillArrayRandom(numOfAttributes + 1, 0, 0);

  for (var i = 0; i < teachingVectors.length; i++) {
    teachingVectors[i][teachingVectors[i].length - 1] = 1;
  }

  funcs = perceptron(teachingVectors, funcs);

  var str = "Classes and images: <br>";
  for (var i = 0; i < amountOfClasses; i++) {
    str += i + 1 + " class: <br>[" + teachingVectors[i].toString() + "]<br>";
  }

  str += "<br>Separating functions:<br>";
  for (var i = 0; i < amountOfClasses; i++) {
    str += "d<sub>" + (i + 1) + "</sub>(x) =";
    for (var j = 0; j < numOfAttributes; j++) {
      str += (funcs[i][j] > 0 ? (!j ? " " : " + ") : " - ") + Math.abs(funcs[i][j]) + "x<sub>" + (j + 1) + "</sub>";
    }
    str += (funcs[i][j] > 0 ? " " : " - ") + Math.abs(funcs[i][j]) + " = ";

    for (var j = 0; j < numOfAttributes; j++) {
      if (funcs[i][j] != 0) {
        str += (funcs[i][j] > 0 ? (!j ? " " : " + ") : " - ") + Math.abs(funcs[i][j]) + "x<sub>" + (j + 1) + "</sub>";
      }
    }
    if (funcs[i][j] != 0) {
      str += (funcs[i][j] > 0 ? (!j ? " " : " + ") : " - ") + Math.abs(funcs[i][j]);
    }
    str += "<br>";
  }

  document.getElementById("text").innerHTML = str;

  str = "Classify vector: <br><table><tr>";
  for (var i = 0; i < numOfAttributes; i++) {
    str += '<td><input type="text" id="inp' + i + '"></td>';
  }
  str +=
    '<td><input type="text" id="inpLast" value="1" disabled></td><td><button id="btn0">Classify</button></td></tr></table>';
  document.getElementById("inp").innerHTML = str;

  btn0.onclick = function () {
    var arr = Array(numOfAttributes);
    for (var i = 0; i < numOfAttributes; i++) {
      arr[i] = parseInt(document.getElementById("inp" + i).value);
    }
    arr.push(1);

    var results = Array(funcs.length);
    for (var i = 0; i < funcs.length; i++) {
      results[i] = funcs[i].multiplyArray(arr).reduce((a, b) => a + b);
    }
    var max = results.getMax();
    document.getElementById("res").innerHTML = "This vector belongs to " + (max.index + 1) + " class";
  };
};

function perceptron(teachingVectors, funcs) {
  var results,
    max,
    iterationsCount = 0,
    ok = true;
  while (ok && ++iterationsCount < 100) {
    ok = false;
    // In one pass we go through all learning vectors.

    // Loop over class images.
    for (var j = 0; j < teachingVectors.length; j++) {
      results = Array(funcs.length);
      for (var i = 0; i < funcs.length; i++) {
        // Sum of the product of the training vector and their function.
        results[i] = funcs[i].multiplyArray(teachingVectors[j]).reduce((a, b) => a + b);
      }
      max = results.getMax();

      // If the products are greater than or equal, we introduce corrections.
      if (!max.unique || max.index != j) {
        ok = true;
        for (var g = 0; g < funcs.length; g++) {
          // The required function is summed, the rest in the difference
          if (g === j) {
            funcs[g] = funcs[g].sumArray(teachingVectors[j]);
          } else {
            funcs[g] = funcs[g].differenceArray(teachingVectors[j]);
          }
        }
      }
    }
  }

  return funcs;
}
