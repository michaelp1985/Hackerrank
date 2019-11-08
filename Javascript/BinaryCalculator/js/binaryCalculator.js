var equation = '';  

function btnClick(val){
    
    var res = document.getElementById('res');
    
    if (val === '='){
        
        var reNums = /\d+/g;
        var reQuo = /[+|-|*|/]/g
        
        var num1 = reNums.exec(equation);
        var quo = reQuo.exec(equation);
        var num2 = reNums.exec(equation);
                
        var a = parseInt(num1, 2);         
        var b = parseInt(num2, 2);
        var answer = 0;
        
        if (quo == '+'){
            answer = a + b;            
        }       
        else if(quo == '-'){
            answer = a - b;
        }
        else if(quo == '*'){
            answer = a * b;
        }
        else if (quo == '/'){
            answer = parseInt(a / b);
        }
        
        equation = Number(answer).toString(2);
    }
    else if (val === 'C'){
        equation = '';        
    }
    else{
        equation += val;                       
    }
    
    res.innerText = equation;
  }