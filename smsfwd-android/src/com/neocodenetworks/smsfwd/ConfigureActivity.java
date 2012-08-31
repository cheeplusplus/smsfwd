// SMSFWD by Andrew Koester <andrew@neocodenetworks.com>

package com.neocodenetworks.smsfwd;

import android.os.Bundle;
import android.preference.PreferenceActivity;

public class ConfigureActivity extends PreferenceActivity {
	 /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        addPreferencesFromResource(R.xml.prefs);
    }
    
    @Override
    protected void onPause() {
    	super.onPause();
    	
    	// Close the activity on pause so firing
    	//  AlertActivity doesn't come up on top of us
    	this.finish();
    }
}
