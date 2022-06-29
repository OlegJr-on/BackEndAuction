function Lot(props){
    const {
        id, 
        Title,
        StartPrice,
        StartDate,
        EndDate,
        PhotoSrc
    } = props;

    return <div className="card lot">
    <div className="card-image waves-effect waves-block waves-light">
      <img className="activator" src={PhotoSrc}/>
    </div>
    <div className="card-content">
      <span className="card-title activator grey-text text-darken-4">{Title}</span>
      <p>{StartPrice}</p>
    </div>
  </div>
}

export {Lot}