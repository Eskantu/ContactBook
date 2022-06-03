export default
  [
  { title: "Dashboard", icon: "dashboard", to: "/" },
  { title: "Users", icon: "account_circle", to: "/Users" },
  {
    title: "Contact Book",
    icon: "contact_page",
    to: "Users",
    items: [
      { title: "Contactos", icon: "list_alt", to: "/ContactBook/Contactos" },
      { title: "Estado Civil", icon: "favorite", to: "/ContactBook/EstadoCivil" },
      { title: "Tipo Contacto", icon: "connect_without_contact", to: "/ContactBook/TipoContacto" },
    ],
  },
  { title: "Projects", icon: "folder", to: "/Projects" },
  { title: "Draw CSS", icon: "format_paint", to: "/CSS" },
  { title: "Upload file", icon: "file_upload", to: "/FILE" },
  { title: "About", icon: "help", to: "About" },
]