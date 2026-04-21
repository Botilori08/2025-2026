let fileNev = "vonat.txt";

const adatok = [];

document.body.onload = betolt();

function betolt()
{
    fetch(fileNev)
    .then(x => x.text())
    .then(x =>
        {
            /*console.log(x);

            let minta = /(\d+)\t(\d+)\t(\d+)\t([IE])/g;

            let sorok = x.match(minta)
            */
            //AI Help
            const regex = /^(?<vonatId>\d+)\s+(?<allomasId>\d+)\s(?<ora>\d+)\s(?<perc>\d+)\s(?<tipus>[IE])$/gm;

            let sorok2 = x.match(regex);

            while((match = regex.exec(x)) !== null)
            {
                adatok.push(match.groups);
                adatok.at(-1)["idoPercben"] = parseInt(adatok.at(-1).ora)*60 + parseInt(adatok.at(-1).perc);
            }
            
            console.log(adatok)
            
        }
    )
}


function feladat2()
{

    let vonatSzamkiir = document.getElementById("vonatSzam");

    let allomasSzamkiir = document.getElementById("allomasSzam");

    let vonatMax = 0;
    let allomasMax = 0;

    adatok.forEach(x => {

        if(parseInt(x.vonatId) > vonatMax )
        {
            vonatMax = parseInt(x.vonatId);
            

        }
        if(parseInt(x.allomasId) > allomasMax)
        {
            allomasMax = parseInt(x.allomasId);
        }
    })

    vonatSzamkiir.innerHTML = vonatMax;

    allomasSzamkiir.innerHTML = allomasMax+1;

    //console.log(vonatMax)
}

function feladat3()
{

    let rendezett = adatok.toSorted((a,b) => parseInt(a.allomasId) - parseInt(b.allomasId))
	.toSorted((a,b) => parseInt(a.vonatId) - parseInt(b.vonatId));

	const varakozasok = [,[]];

	for(let i = 1;i < rendezett.length-1;i+=2)
	{
		//de ez még nem
        if(rendezett[i].vonatId!== rendezett[i+1].vonatId)
        { 
		    varakozasok.push([]);
        } 
        else
        {
            varakozasok[rendezett[i].vonatId].push(rendezett[i+1].idoPercben - rendezett[i].idoPercben);
        }

	}

    let max = -1
    let vonatMax = 0;
    let allomasMax = 0;

    for(let i = 1;i < varakozasok.length;i++)
    {
        for(let j = 0;j < varakozasok[i].length;j++)
        {
            if(max < varakozasok[i][j])
            {
                max = varakozasok[i][j]
                vonatMax = i;
                allomasMax = j+1;
            }
        }
    }

    max = Math.max(...varakozasok.flat());

    const szurt = varakozasok.filter(egyVonat =>
        {
            let f = egyVonat.filter(egyIdo => egyIdo == max);
            return f;
        }
    );


    let szurtSzurt = szurt.filter((e,i) => {
        if(x.length > 0)
        {
            return i;
       }
    })

    console.log(szurt)

    document.getElementById("vonatSzama").innerHTML = vonatMax
    document.getElementById("allomas").innerHTML = allomasMax
    document.getElementById("varakozasido").innerHTML = max



}


