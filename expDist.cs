class expCDF{

    public double randEvents(int lambda, int setSize, double inc)
    {
        double startVal = 0;  //starting value of the range if off 0
        double eventNum = 0;  //number chosen
        if (lambda - (setSize / 2) > 0)
            startVal = lambda - (setSize / 2); //if range is off 0, set new starting value
        double[] probs = assignParts(lambda, setSize, inc); //assign probabilities
        double rand = Random.value; //rand value to be mapped
        for (int i = 0; i < setSize; i++)
        { //check for when it no longer exceeds prob
            if (rand < probs[i])
            {
                eventNum = (i*inc + startVal);
                break;
            }
        }
        if (probs[setSize - 1] < rand)
        { //if it exceeds highest partition set to highest partition+1 
            eventNum = startVal + setSize*(inc);
        }
        return eventNum;
    }

    public double[] assignParts(int lambda, int setSize, double inc)
    {
        double[] parts = new double[setSize]; //create array with number of partitions accordingly
        double startVal = 0;
        if (lambda - (setSize / 2) > 0)
            startVal = lambda - (setSize / 2);
        //(1-e^(-lambda*x))
        double eVal; //calculated exponential value for every x
        for (int i = 0; i < setSize; i++)
        {
            eVal = 1 - (System.Math.Pow(System.Math.E, (-lambda * startVal)));
            parts[i] = eVal;
            startVal+=inc;
        }
        return parts; //return set of probabilities
    }
}