// SMSFWD by Andrew Koester <andrew@neocodenetworks.com>

package com.neocodenetworks.smsfwd;

import android.app.*;
import android.content.*;
import android.content.DialogInterface.OnClickListener;
import android.os.Bundle;

public class AlertActivity extends Activity {
	public final static String ALERT = "com.neocodenetworks.smsfwd.ALERT";
	public final static String ALERT_EXTRA_TITLE = "title";
	public final static String ALERT_EXTRA_MESSAGE = "message";
	public final static String ALERT_EXTRA_SHOWCONF = "showconfig";
	
	 /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        
        Intent intent = getIntent();
       
		if (intent.getAction().equals(ALERT)) {
			Bundle bundle = intent.getExtras();
			if (bundle.containsKey(ALERT_EXTRA_TITLE) && bundle.containsKey(ALERT_EXTRA_MESSAGE))
			{
				String title = bundle.getString(ALERT_EXTRA_TITLE);
				String message = bundle.getString(ALERT_EXTRA_MESSAGE);
				
				final Boolean showConfig = (bundle.containsKey(ALERT_EXTRA_SHOWCONF) && bundle.getBoolean(ALERT_EXTRA_SHOWCONF));
				
				AlertDialog.Builder builder = new AlertDialog.Builder(this);
				builder.setTitle(title).setMessage(message).setCancelable(false)
					.setNeutralButton("OK", new OnClickListener() {
						@Override
						public void onClick(DialogInterface dialog, int which) {
							dialog.dismiss();
							
							if (showConfig)
							{
								Intent i = new Intent(AlertActivity.this, ConfigureActivity.class);
								AlertActivity.this.startActivity(i);								
							}
							
							AlertActivity.this.finish();
						}
					});
				
				AlertDialog alert = builder.create();
				alert.show();
			}
		}
	}
}
