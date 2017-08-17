class poissonCDF{

	public int randEvents(int lambda, int setSize){
		int startVal = 0;  //starting value of the range if off 0
		int eventNum = 0;  //number chosen
		if(lambda-(setSize/2)>0)
			startVal = lambda - (setSize/2); //if range is off 0, set new starting value
		double[] probs = assignParts(lambda, setSize); //assign probabilities
		double rand = Random.value; //rand value to be mapped
		for(int i = 0; i < setSize; i++){ //check for when it no longer exceeds prob
			if(rand < probs[i]){
				eventNum = (i+startVal);
				break;
			}
		}
		if(probs[setSize-1] < rand){ //if it exceeds highest partition set to highest partition+1 
			eventNum = startVal+setSize;
		}
		return eventNum;

	}
    public double[] assignParts(int lambda, int setSize){
		double[] parts = new double[setSize]; //create array with number of partitions accordingly
		int startVal = 0;
		if(lambda-(setSize/2) > 0)
			startVal = lambda - (setSize/2);
		double sum = 0;
		//((e^-lambda)(lambda^x))/(x!)
		double pVal; //calculated poisson value for every x
		if(startVal > 0){
			for(int j = 0; j < startVal; j++){
				pVal = ((Math.Pow(Math.E, (-1*lambda))*Math.Pow(lambda, j))/factorial(j)); //calculate poisson
				sum+=pVal; //cummulative distribution
			}
		}
		for(int i = 0; i < setSize; i++){
			pVal = ((Math.Pow(Math.E, (-1*lambda))*Math.Pow(lambda, startVal))/factorial(startVal)); //calculate poisson
			sum+=pVal; //cummulative distribution
			parts[i] = sum; 
			startVal++;
		}
    	return parts; //return set of probabilities
    }
    public double factorial(int number){
		    if (number == 1)
		        return 1;
		    else
		        return number * factorial(number - 1);
	}
}