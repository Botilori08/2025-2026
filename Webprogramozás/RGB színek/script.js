betolt();

let kepAdatok = [];

function betolt()//1.feladat
{   
    fetch("kep.txt")
    .then(x=> x.text())
    .then(y =>
        {
            console.log(y);

            const sorok = y.split("\r\n");


            sorok.forEach((e,index) =>
                {

                    kepAdatok.push([]);

                    let tablaSor =document.createElement("tr");


                    const adatok = e.split(" ");
                    for(let j = 0;j < adatok.length;j+=3)
                    {
                        let pixel = {
                            r:parseInt(adatok[j]),
                            g:parseInt(adatok[j+1]),
                            b:parseInt(adatok[j+2]),
                            RGB: `RGB(${adatok[j]},${adatok[j+1]},${adatok[j+2]})`,
                            x: j/3,
                            y:index,


                        }

                        let cella = document.createElement("td");
                        cella.style.backgroundColor = pixel.RGB;
                        pixel["cella"] = cella;
                        tablaSor.appendChild(cella);

                        pixel["RGBSum"] = pixel.r+pixel.g+pixel.b;

                        kepAdatok[kepAdatok.length-1].push(pixel);
                    }
                    document.querySelector("#kep table").appendChild(tablaSor);
        });

            console.log(sorok);

            console.log(kepAdatok);

        }
    )
}

function feladat2()
{
    
    let sor = parseInt(document.getElementById("sorSzam").value) ?? 1;
    
    let oszlop = parseInt(document.getElementById("oszlopSzam").value) ?? 1;

    document.getElementById("feladat2-eredmeny").innerHTML = kepAdatok[sor-1][oszlop-1].RGB;

    kepAdatok[sor-1][oszlop-1].cella.style.backgroundColor = "yellow";
}


function feladat3()
{

    let vilagosak = 0;

    vilagosak = kepAdatok.flat().filter(x => x.RGBSum > 600);

    //console.log(vilagosSzam);

    document.getElementById("feladat3-eredmeny").innerHTML = vilagosak.length;
}

function feladat4()
{
    let minimum = kepAdatok[0][0].RGBSum;
    
    kepAdatok.flat().forEach(e => 
        {
            if(e.RGBSum < minimum)
            {
                minimum = e.RGBSum;
            }
        }
    )
    console.log(minimum)

    document.getElementById("feladat4-eredmeny").innerHTML = minimum;

    let sotet = [];

    kepAdatok.flat().forEach(e => 
        {
            if(e.RGBSum == minimum)
            {
                sotet.push(e.RGB);
                console.log(e.x,e.y);
                keretKeszit(e);
            }
        }
    )

    document.getElementById("feladat4-lista").innerHTML = "";

    let lista = document.createElement("ol");

    sotet.forEach(e => {

        let listaElem = document.createElement("li")
        listaElem.innerText = e;
        lista.appendChild(listaElem)
    })

    document.getElementById("feladat4-lista").appendChild(lista);


    /*
    Másik megoldás innerHTML-lel
    
    let szoveg = "<ol><li>"+sotet.join("</li><li>")+"</li></ol>";

    document.getElementById("feladat4-lista").innerHTML = szoveg;
    */


}

function keretKeszit(e)
{
    //Bal oldalon van x == 0

    console.log("képpont:",e.x,":",e.y)

    if(kepAdatok[e.y-1] != undefined && kepAdatok[e.y-1][e.x-1] != undefined) kepAdatok[e.y-1][e.x-1].cella.backgroundColor = "yellow";
    if(kepAdatok[e.y-1] != undefined && kepAdatok[e.y-1][e.x-1] != undefined) kepAdatok[e.y-1][e.x].cella.backgroundColor = "yellow";
    if(kepAdatok[e.y-1] != undefined && kepAdatok[e.y-1][e.x-1] != undefined) kepAdatok[e.y-1][e.x+1].cella.backgroundColor = "yellow";

    if(kepAdatok[e.y-1] != undefined && kepAdatok[e.y-1][e.x-1] != undefined) kepAdatok[e.y][e.x-1].cella.backgroundColor = "yellow";
    if(kepAdatok[e.y-1] != undefined && kepAdatok[e.y-1][e.x-1] != undefined) kepAdatok[e.y][e.x].cella.backgroundColor = "yellow";
    if(kepAdatok[e.y-1] != undefined && kepAdatok[e.y-1][e.x-1] != undefined) kepAdatok[e.y][e.x+1].cella.backgroundColor = "yellow";



}