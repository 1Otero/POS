var url = location.href
var carro = []
var productos = []
var carroVer = document.getElementById("verCarrito")
var pagar = document.getElementById("pagar")
var ValorTotalCli = 0;

$("document").ready(() => {
    carroVer.style.display = 'none'
    pagar.style.display = 'none'
    $.ajax({url: `${url}Home/getDatos`,
        success: (e) => {productos.push(e.f)},
        error: (ee) => {console.log(ee)}})})

function agregar(id) {
    var IdProducto = id
    console.log("Agregando " + IdProducto)
    if (carro.length > 0) {
        var producto = productos[0].find(e => e.Id == IdProducto)
            if (carro[0].find(e => e.Id == IdProducto)) {
                carro[0].forEach(e => {
                    if (e.Id == IdProducto) {
                        e.Cantidad += 1
                        console.log(carro)
                    }
                })
                pintarHtml()
            } else {
                producto.Cantidad= 1
                carro[0].push(producto)
                pintarHtml()
        }

    } else {
        carroVer.style.display= 'block'
        pagar.style.display = 'block'
        var pag = document.getElementById("pagar")
        pag.addEventListener("click", e => {
            console.log("Entro boton")
            e.preventDefault()
            //pagarCarrito()
        })
        var producto = productos[0].filter(e => e.Id == IdProducto)
        producto[0].Cantidad= 1
        carro.push(producto)
        /*var valorPintar = document.getElementById("totalValor");
        carro[0].forEach(e => ValorTotalCli += e.Cantidad * e.ValorTotal)
        valorPintar.innerHTML = `<tr><th colspan="4">Valor Total: ${ValorTotalCli}</th></tr>`*/
        pintarHtml()
    }
    console.log(carro)
    refrescarCarrito()
}

function refrescarCarrito() {
    var carrito = document.getElementById("carrito")
    var products = '';
    carro[0].map(e => {
        products +=`<tr><th>${e.Producto}</th>
             <th>${e.Cantidad}</th>
             <th>${e.ValorUnitario}</th></tr>`
    })
    carrito.innerHTML = products
}
function editar(e) {
    location.replace(`${url}Home/Edit?Id=${e}`)
}


function pagarCarrito() {
    var Cedula = document.getElementById("Cedula").value | "77777"
    var Nombre = document.getElementById("Nombre").value == null ? "fff" : document.getElementById("Nombre").value
    var Apellido = document.getElementById("Apellido").value == null ? "fff" : document.getElementById("Apellido").value
    var Telefono = document.getElementById("Telefono").value | "77777"
    var cliente = {
        Cedula,
        Nombre,
        Apellido,
        Telefono
    }
    if (!Cedula && !Nombre && Apellido && Telefono) {
        console.log("Debe agregar los datos del usuario")
    } else {
        console.log("cliente")
        console.log(cliente)
        console.log("Products")
        console.log(carro[0])
    }
    var ValorTotalCli = 0;
    carro[0].forEach(e => ValorTotalCli += e.Cantidad * e.ValorTotal )
    console.log(ValorTotalCli)
    console.log(carro)
    $.ajax({
        url: `${url}Home/Pagar`,
        method: 'POST',
        data: {
            client: cliente,
            products: carro[0]
        },
        success: (e) => {
            console.log(e)
            location.replace(`${url}`)
        }, err: (e) => console.log(e)
    })
}
function pintarHtml() {
    var valorPintar = document.getElementById("totalValor");
    ValorTotalCli = 0
    carro[0].forEach(e => ValorTotalCli += e.Cantidad * e.ValorUnitario)
    valorPintar.innerHTML = `<tr><th colspan="4">Valor Total: ${ValorTotalCli}</th></tr>`
    console.log(ValorTotalCli)
}