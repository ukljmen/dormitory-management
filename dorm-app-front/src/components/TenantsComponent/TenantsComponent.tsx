interface Props {
  tenants: string[];
}

function TenantsList(props: Props) {
  //let lokatorzy = ["lokator1", "lokator2"];

  const checkTenants =
    props.tenants.length === 0 ? <p>Brak lokatorów</p> : null;

  function SendMessage() {
    console.log("wyslij");
  }

  function DeleteTenant() {
    console.log("usuń");
  }

  function AddTenant() {
    console.log("dodaj");
  }

  return (
    <div className="TenantsComponent">
      <h2>Lokatorzy</h2>
      {checkTenants}

      <ul>
        {props.tenants.map((tenants) => (
          <li key={tenants}>
            {tenants}
            <button onClick={SendMessage}>Wyślij Komunikat</button>{" "}
            <button onClick={DeleteTenant}>Usuń Lokatora z Pokoju</button>
          </li>
        ))}
      </ul>

      <button className="btn-add-tenant" onClick={AddTenant}>
        Dodaj Lokatora
      </button>
    </div>
  );
}

export default TenantsList;
