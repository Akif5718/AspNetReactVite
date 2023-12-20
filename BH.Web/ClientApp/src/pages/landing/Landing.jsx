import './landing.scss'
import logo  from '../../assets/logo.png'

const Landing = () => {
    return (
        <div className='landing'>
            <div className="headerSection flex justify-between mt-5 mx-10">
                <div className="logo">
                    <img src={logo} alt="BinaryHire Logo" className='object-contain h-24 w-24' />
                </div>
                <div className="menu flex mt-5">
                    <ul className='flex gap-5'>
                        <li><a href="#">LOGIN</a></li>
                        <li><a href="#" className='text-violet-500'>BOOK A DEMO</a></li>
                    </ul>
                </div>
            </div>
        </div>
    );
}

export default Landing;
