﻿<%@ Application Language="C#" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        Application.Lock();
        Application["Sessions"] = 0;
        Application["Loggeds"] = 0;
        Application.UnLock();

        Comercio aux = Comercio.Instancia;
        Usuario.ErroresUsuario resultUsuario;
        Categoria.ErroresCategoria resultCategoria;
        Producto.ErroresProducto resultProducto;
        int resultPedido1;
        int resultPedido2;
        int resultPedido3;
        int resultPedido4;
        //Direcciones
        List<string> dir1 = ("Bogota 3480,Rio 852").Split(',').ToList();
        List<string> dir2 = ("Wallstreet 56,St. German 452,Calle No.5").Split(',').ToList();
        List<string> dir3 = ("Roxlo 1246,Indio Solari 65,Ricota 32").Split(',').ToList();
        List<string> dir4 = ("Rocha 223,Veneto 2358,Peron 34534").Split(',').ToList();
        List<string> dir5 = ("Uruguay 1950,Brazil 2014,SDF 5248,Paris 876").Split(',').ToList();
        List<string> dir6 = ("BSOD 55,49 Street,America 786,Call 456").Split(',').ToList();
        //Passwords
        string auxPass = StringCipher.Encrypt("1234", "mkJcqDqU");
        //Usuarios
        resultUsuario = aux.altaUsuario("Admin@comercio.com", auxPass, "Street 1818", dir1, Usuario.TipoUsuario.Admin);
        resultUsuario = aux.altaUsuario("Gerente@comercio.com", auxPass, "Pereira 1546", dir2, Usuario.TipoUsuario.Gerente);
        resultUsuario = aux.altaUsuario("JefeDeDeposito@comercio.com", auxPass, "18 De Julio 5112", dir3, Usuario.TipoUsuario.JefeDeDeposito);
        resultUsuario = aux.altaUsuario("Cliente@comercio.com", auxPass, "26 De Marzo 4531", dir4, Usuario.TipoUsuario.Cliente);
        resultUsuario = aux.altaUsuario("Inactivo@comercio.com", auxPass, "Bogota 4453", dir5, Usuario.TipoUsuario.Cliente);
        resultUsuario = aux.altaUsuario("Baneado@comercio.com", auxPass, "Infierno 153", dir6, Usuario.TipoUsuario.Cliente); // Activo pero baneado.
        //Usuarios activos
        Usuario activarAdmin = Comercio.Instancia.buscarUsuarioXUser("Admin@comercio.com");
        activarAdmin.Inactivo = false;
        Usuario activarGerente = Comercio.Instancia.buscarUsuarioXUser("Gerente@comercio.com");
        activarGerente.Inactivo = false;
        Usuario activarJefeDeDeposito = Comercio.Instancia.buscarUsuarioXUser("JefeDeDeposito@comercio.com");
        activarJefeDeDeposito.Inactivo = false;
        Usuario activarCliente = Comercio.Instancia.buscarUsuarioXUser("Cliente@comercio.com");
        activarCliente.Inactivo = false;
        Usuario activarBaneado = Comercio.Instancia.buscarUsuarioXUser("Baneado@comercio.com");
        activarBaneado.Inactivo = false;
        //Baneados
        Usuario aBanear = Comercio.Instancia.buscarUsuarioXUser("Baneado@comercio.com");
        aBanear.Ban = true;
        //Categorias
        resultCategoria = aux.altaCategoria("Animales");
        resultCategoria = aux.altaCategoria("Comidas");
        resultCategoria = aux.altaCategoria("Armas");
        resultCategoria = aux.altaCategoria("Otros");
        resultCategoria = aux.altaCategoria("Herramientas");
        //Productos
        resultProducto = aux.altaProducto(aux.buscarCategoriaXNombreCat("Animales"), "Gatito", 3, 2, "Gatito.png", 600);
        resultProducto = aux.altaProducto(aux.buscarCategoriaXNombreCat("Animales"), "Gato", 4, 3, "Gato.png", 800);
        resultProducto = aux.altaProducto(aux.buscarCategoriaXNombreCat("Comidas"), "Sushi", 10, 5, "Sushi.png", 180);
        resultProducto = aux.altaProducto(aux.buscarCategoriaXNombreCat("Comidas"), "Ramen", 20, 10, "Ramen.png", 90);
        resultProducto = aux.altaProducto(aux.buscarCategoriaXNombreCat("Comidas"), "Onigiri", 10, 20, "Onigiri.png", 30);
        resultProducto = aux.altaProducto(aux.buscarCategoriaXNombreCat("Armas"), "Bazooka", 5, 6, "Bazooka.png", 6600);
        resultProducto = aux.altaProducto(aux.buscarCategoriaXNombreCat("Armas"), "Misil", 8, 2, "Misil.png", 8500);
        resultProducto = aux.altaProducto(aux.buscarCategoriaXNombreCat("Armas"), "Bomba", 20, 4, "Bomba.png", 220);
        resultProducto = aux.altaProducto(aux.buscarCategoriaXNombreCat("Armas"), "Zombie", 2, 1, "Zombie.png", 220);
        resultProducto = aux.altaProducto(aux.buscarCategoriaXNombreCat("Animales"), "GatoSinImagen", 6, 2, "", 500);
        resultProducto = aux.altaProducto(aux.buscarCategoriaXNombreCat("Otros"), "Brazil2014", 9, 1, "Brazil2014.png", 422);
        resultProducto = aux.altaProducto(aux.buscarCategoriaXNombreCat("Herramientas"), "Martillo", 4, 8, "Martillo.png", 50);
        resultProducto = aux.altaProducto(aux.buscarCategoriaXNombreCat("Herramientas"), "Llave", 15, 10, "Llave.png", 60);
        //Monto para pedidos
        Decimal auxMonto1;
        if (Decimal.TryParse("1400", out auxMonto1)) { }
        Decimal auxMonto2;
        if (Decimal.TryParse("9700", out auxMonto2)) { }
        Decimal auxMonto3;
        if (Decimal.TryParse("1800", out auxMonto3)) { }
        Decimal auxMonto4;
        if (Decimal.TryParse("9700", out auxMonto4)) { }
        //Pedidos        
        Producto Gatito = Comercio.Instancia.buscarProductoXNombreProd("Gatito");
        Producto Gato = Comercio.Instancia.buscarProductoXNombreProd("Gato");
        Producto Sushi = Comercio.Instancia.buscarProductoXNombreProd("Sushi");
        Producto Bomba = Comercio.Instancia.buscarProductoXNombreProd("Bomba");
        Producto Misil = Comercio.Instancia.buscarProductoXNombreProd("Misil");
        Producto Llave = Comercio.Instancia.buscarProductoXNombreProd("Llave");
        List<Producto> paraPedido1 = new List<Producto>();
        paraPedido1.Add(Gatito);
        paraPedido1.Add(Gato);
        List<Producto> paraPedido2 = new List<Producto>();
        paraPedido2.Add(Sushi);
        paraPedido2.Add(Bomba);
        paraPedido2.Add(Gato);
        paraPedido2.Add(Misil);
        List<Producto> paraPedido3 = new List<Producto>();
        paraPedido3.Add(Sushi);
        paraPedido3.Add(Bomba);
        paraPedido3.Add(Gato);
        paraPedido3.Add(Gatito);
        List<Producto> paraPedido4 = new List<Producto>();
        paraPedido4.Add(Gato);
        paraPedido4.Add(Misil);
        paraPedido4.Add(Bomba);
        paraPedido4.Add(Sushi);
        resultPedido1 = aux.altaPedido(true, paraPedido1, DateTime.Now, "Pereira 1546", auxMonto1);
        resultPedido2 = aux.altaPedido(false, paraPedido2, DateTime.Now, "Artigas 4123", auxMonto2);
        resultPedido3 = aux.altaPedido(true, paraPedido3, DateTime.Now, "26 De Marzo 4531", auxMonto3);
        resultPedido4 = aux.altaPedido(false, paraPedido4, DateTime.Now, "Rio 852", auxMonto4);
        //Asignar pedidos a usuarios
        Usuario usu1 = Comercio.Instancia.buscarUsuarioXUser("Admin@comercio.com");
        Pedido pedido1 = Comercio.Instancia.buscarPedidoXCodPedido(1);
        Pedido pedido2 = Comercio.Instancia.buscarPedidoXCodPedido(2);
        usu1.ColPedidos.Add(pedido1);
        usu1.ColPedidos.Add(pedido2);
        Usuario usu2 = Comercio.Instancia.buscarUsuarioXUser("Cliente@comercio.com");
        Pedido pedido3 = Comercio.Instancia.buscarPedidoXCodPedido(3);
        Pedido pedido4 = Comercio.Instancia.buscarPedidoXCodPedido(4);
        usu2.ColPedidos.Add(pedido3);
        usu2.ColPedidos.Add(pedido4);
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started
        Session["Logged"] = false;
        Session["User"] = "Visitante temp.";
        Session["Type"] = Usuario.TipoUsuario.Visitante;

        Application.Lock();
        Application["Sessions"] = (int)Application["Sessions"] + 1;
        Application.UnLock();
    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        Application.Lock();
        Application["Sessions"] = (int)Application["Sessions"] - 1;
        Application.UnLock();
    }
       
</script>
